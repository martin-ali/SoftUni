using Suls.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }
        public HttpResponse Create()
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/Users/login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/Users/login");
            }

            var nameIsValid = string.IsNullOrWhiteSpace(name) == false
                && name.Length >= 5
                && name.Length <= 20;
            if (nameIsValid == false)
            {
                return this.Error("Name should be between 5 and 20 characters");
            }

            var pointsAreValid = 50 <= points && points <= 300;
            if (pointsAreValid == false)
            {
                return this.Error("Points should be between 50 and 300");
            }

            this.problemsService.Create(name, (ushort)points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/Users/login");
            }

            var problemViewModel = this.problemsService.GetById(id);

            return this.View(problemViewModel);
        }
    }
}