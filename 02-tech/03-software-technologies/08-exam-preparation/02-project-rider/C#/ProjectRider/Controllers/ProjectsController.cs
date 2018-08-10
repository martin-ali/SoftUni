
namespace ProjectRider.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using ProjectRider.Models;

    public class ProjectController : Controller
    {
        private readonly ProjectDbContext context;

        public ProjectController(ProjectDbContext context) => this.context = context;

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var projects = this.context.Projects.ToList();

            return View(projects);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create() => View();

        [HttpPost]
        [Route("create")]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid == false)
            {
                return View(project);
            }

            this.context.Projects.Add(project);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            var project = this.context.Projects.Find(id);

            if (project == null) return NotFound();

            return View(project);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Project projectModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(projectModel);
            }

            var project = this.context.Projects.Find(id);
            project.Title = projectModel.Title;
            project.Description = projectModel.Description;
            project.Budget = projectModel.Budget;

            this.context.Update(project);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var project = this.context.Projects.Find(id);

            if (project == null) return NotFound();

            return View(project);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Project projectModel)
        {
            var project = this.context.Projects.Find(id);

            if (project == null) return NotFound();

            this.context.Projects.Remove(project);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
