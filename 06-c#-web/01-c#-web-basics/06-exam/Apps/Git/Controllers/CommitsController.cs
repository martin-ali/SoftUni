namespace Git.Controllers
{
    using Git.Common;
    using Git.Services;
    using Git.ViewModels.Commits;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;

        public CommitsController(ICommitsService commitsService)
        {
            this.commitsService = commitsService;
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

            var commitCreateViewModel = this.commitsService.GetRepositoryById(id);
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