namespace IssueTracker.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using IssueTracker.Models;
    using System.Linq;

    public class IssueController : Controller
    {
        private readonly IssueDbContext context;

        public IssueController(IssueDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var issue = this.context.Issues.ToList();

            return View(issue);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create() => View();

        [HttpPost]
        [Route("create")]
        public ActionResult Create(Issue issue)
        {
            if (ModelState.IsValid == false)
            {
                return View(issue);
            }

            this.context.Issues.Add(issue);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            var issue = this.context.Issues.Find(id);

            if (issue == null) return NotFound();

            return View(issue);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Issue issueModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(issueModel);
            }

            var issue = this.context.Issues.Find(id);
            issue.Title = issueModel.Title;
            issue.Content = issueModel.Content;
            issue.Priority = issueModel.Priority;

            this.context.Update(issue);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var project = this.context.Issues.Find(id);

            if (project == null) return NotFound();

            return View(project);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Issue issueModel)
        {
            var issue = this.context.Issues.Find(id);

            if (issue == null) return NotFound();

            this.context.Issues.Remove(issue);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
