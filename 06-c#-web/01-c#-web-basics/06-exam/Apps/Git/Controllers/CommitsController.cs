namespace Git.Controllers
{
    using Git.Common;
    using Git.Services;
    using Git.ViewModels.Commits;
    using Git.ViewModels.Repositories;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/");
            }

            var commitsViewModel = this.commitsService.GetAllByUserId(this.GetUserId());
            return this.View(commitsViewModel);
        }

        public HttpResponse Create(string id)
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/");
            }

            var repository = this.repositoriesService.GetById(id);
            var commitCreateViewModel = new CommitCreaterepositoryViewModel
            {
                RepositoryId = repository.Id,
                RepositoryName = repository.Name
            };

            return this.View(commitCreateViewModel);
        }

        [HttpPost]
        public HttpResponse Create(CommitInputModel input)
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/");
            }

            var commitDescriptionIsValid = string.IsNullOrWhiteSpace(input.Description) == false
                && input.Description.Length >= Constants.CommitDescriptionMinLength;
            if (commitDescriptionIsValid == false)
            {
                return this.Error(Messages.UnderAllowedCharacters("Description", Constants.CommitDescriptionMinLength));
            }

            this.commitsService.CreateCommit(input, this.GetUserId());

            return this.Redirect("/Repositories/All");
        }

        // Only owner can delete
        public HttpResponse Delete(string id)
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/");
            }

            var commit = this.commitsService.GetById(id);
            if (commit.CreatorId != this.GetUserId())
            {
                return this.Error(Messages.OnlyOwnerCanDelete("commit"));
            }

            this.commitsService.DeleteById(id);

            return this.Redirect("/Commits/All");
        }
    }
}