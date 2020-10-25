using System.Collections.Generic;
using Suls.Services;
using Suls.ViewModels.Problems;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                // Viewmodel argument for the page
                var problems = this.problemsService.GetAll();
                return this.View(problems, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}