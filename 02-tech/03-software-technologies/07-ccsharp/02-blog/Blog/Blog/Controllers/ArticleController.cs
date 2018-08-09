using System;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public UserManager<ApplicationUser> UserManager { get; set; }

        public ArticleController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.UserManager = userManager;
            this.context = context;
        }

        private bool UserIsAuthorizedToEdit(Article article)
        {
            var isAdmin = this.User.IsInRole("Admin");
            var isAuthor = article.IsAuthor(this.User.Identity.Name);

            return isAdmin || isAuthor;
        }

        private ApplicationUser GetCurrentUser()
        {
            return this
                    .context
                    .Users
                    .Where(u => u.UserName == this.User.Identity.Name)
                    .First();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult List()
        {
            var articles = this
                            .context
                            .Articles
                            .Include(a => a.Author)
                            .ToList();

            return View(articles);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var article = this
                            .context
                            .Articles
                            .Include(a => a.Author)
                            .Include(a => a.Comments)
                            .ThenInclude(c => c.Author)
                            .FirstOrDefault(a => a.Id == id);

            if (article == null) return NotFound();

            return View(article);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ArticleViewModel articleModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(articleModel);
            }

            var userId = this.GetCurrentUser().Id;
            var article = new Article(articleModel.Title, articleModel.Content, userId);

            this.context.Add(article);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var article = this
                            .context
                            .Articles
                            .Include(a => a.Author)
                            .FirstOrDefault(a => a.Id == id);

            if (article == null) return NotFound();
            if (this.UserIsAuthorizedToEdit(article) == false) return Forbid();

            var articleModel = new ArticleViewModel(article.Id, article.Title, article.Content, article.AuthorId);
            return View(articleModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(ArticleViewModel articleModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(articleModel);
            }

            var article = this
                            .context
                            .Articles
                            .Include(a => a.Author)
                            .FirstOrDefault(a => a.Id == articleModel.Id);

            if (article == null) return NotFound();
            if (this.UserIsAuthorizedToEdit(article) == false) return Forbid();

            article.Title = articleModel.Title;
            article.Content = articleModel.Content;

            this.context.Update(article);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var article = this
                            .context
                            .Articles
                            .Include(a => a.Author)
                            .FirstOrDefault(a => a.Id == id);

            if (article == null) return NotFound();
            if (this.UserIsAuthorizedToEdit(article) == false) return Forbid();

            var articleModel = new ArticleViewModel(article.Id, article.Title, article.Content, article.AuthorId);
            return View(articleModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(ArticleViewModel articleModel)
        {
            var article = this
                            .context
                            .Articles
                            .Include(a => a.Author)
                            .FirstOrDefault(a => a.Id == articleModel.Id);

            if (article == null) return NotFound();
            if (this.UserIsAuthorizedToEdit(article) == false) return Forbid();

            this.context.Remove(article);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
