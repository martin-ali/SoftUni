using System;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class CommentController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public UserManager<ApplicationUser> UserManager { get; set; }

        public CommentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.UserManager = userManager;
            this.context = context;
        }

        private bool UserIsAuthorizedToEdit(Comment comment)
        {
            var isAdmin = this.User.IsInRole("Admin");
            var isAuthor = comment.IsAuthor(this.User.Identity.Name);

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
            return RedirectToAction(nameof(Details));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var comment = this
                            .context
                            .Comments
                            .Include(a => a.Author)
                            .FirstOrDefault(a => a.Id == id);

            if (comment == null) return NotFound();

            return View(comment);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(int? articleId)
        {
            if (articleId == null) return NotFound();

            return View(new CommentViewModel { ArticleId = articleId.Value });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CommentViewModel commentModel)
        {
            if (ModelState.IsValid == false) return View(commentModel);

            var userId = this.GetCurrentUser().Id;

            var comment = new Comment(commentModel.Content, userId, commentModel.ArticleId);

            this.context.Comments.Add(comment);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Details), new { comment.Id });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var comment = this
                            .context
                            .Comments
                            .Include(a => a.Author)
                            .FirstOrDefault(a => a.Id == id);

            if (comment == null) return NotFound();
            if (this.UserIsAuthorizedToEdit(comment) == false) return Forbid();

            var commentModel = new CommentViewModel(comment.Id, comment.Content, comment.AuthorId);
            return View(commentModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(CommentViewModel commentModel)
        {
            if (ModelState.IsValid == false) return View(commentModel);

            var comment = this
                            .context
                            .Comments
                            .Include(a => a.Author)
                            .FirstOrDefault(a => a.Id == commentModel.Id);

            if (comment == null) return NotFound();
            if (this.UserIsAuthorizedToEdit(comment) == false) return Forbid();

            comment.Content = commentModel.Content;

            this.context.Comments.Update(comment);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Details), new { comment.Id });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var comment = this
                            .context
                            .Comments
                            .Include(a => a.Author)
                            .FirstOrDefault(a => a.Id == id);

            if (comment == null) return NotFound();
            if (this.UserIsAuthorizedToEdit(comment) == false) return Forbid();

            var commentModel = new CommentViewModel(comment.Id, comment.Content, comment.AuthorId);
            return View(commentModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(CommentViewModel commentModel)
        {
            var comment = this
                            .context
                            .Comments
                            .Include(a => a.Author)
                            .FirstOrDefault(a => a.Id == commentModel.Id);

            if (comment == null) return NotFound();
            if (this.UserIsAuthorizedToEdit(comment) == false) return Forbid();

            this.context.Comments.Remove(comment);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
