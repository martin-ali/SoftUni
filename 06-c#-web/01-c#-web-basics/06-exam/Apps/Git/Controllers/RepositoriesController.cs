namespace Git.Controllers
{
    using System.Linq;
    using Git.Common;
    using Git.Services;
    using Git.ViewModels.Repositories;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoryService;

        public RepositoriesController(IRepositoriesService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            var repositoryViewModel = this.repositoryService.GetAllPublic();
            return this.View(repositoryViewModel);
        }

        public HttpResponse Create()
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(RepositoryInputModel input)
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/");
            }

            var repositoryNameIsValid = string.IsNullOrWhiteSpace(input.Name) == false
                && input.Name.Length >= Constants.RepositoryNameMinLength
                && input.Name.Length <= Constants.RepositoryNameMaxLength;
            if (repositoryNameIsValid == false)
            {
                return this.Error(Messages.WrongLength("Repository name", Constants.RepositoryNameMinLength, Constants.RepositoryNameMaxLength));
            }

            var repositoryTypeIsValid = Constants.AllowedRepositoryTypes.Contains(input.RepositoryType);
            if (repositoryTypeIsValid == false)
            {
                return this.Error(Messages.Invalid("Repository type"));
            }

            this.repositoryService.CreateRepository(input, this.GetUserId());

            return this.Redirect("/Repositories/All");
        }
    }
}