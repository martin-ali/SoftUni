using Suls.Services;
using Suls.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemsService problemService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(IProblemsService problemService, ISubmissionsService submissionsService)
        {
            this.problemService = problemService;
            this.submissionsService = submissionsService;
        }

        public HttpResponse Create(string id)
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/Users/login");
            }

            var name = this.problemService.GetNameById(id);
            var problemViewModel = new CreateSubmissionViewModel
            {
                ProblemId = id,
                Name = name
            };

            return this.View(problemViewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/Users/login");
            }

            var codeIsValid = string.IsNullOrWhiteSpace(code) == false
                && code.Length >= 30
                && code.Length <= 800;
            if (codeIsValid == false)
            {
                return this.Error("Code should be between 30 and 800 characters long");
            }

            var userId = this.GetUserId();
            this.submissionsService.Create(problemId, userId, code);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/Users/login");
            }

            this.submissionsService.Delete(id);

            return this.Redirect("/");
        }
    }
}