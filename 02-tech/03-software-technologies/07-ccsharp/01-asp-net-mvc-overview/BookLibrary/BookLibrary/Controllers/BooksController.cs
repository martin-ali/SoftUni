using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Identity;

namespace BookLibrary.Controllers
{
    public class BooksController : Controller
    {
        #region My code
        private readonly ApplicationDbContext context;

        private readonly UserManager<ApplicationUser> userManager;

        public BooksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public Task<ApplicationUser> GetCurrentUserAsync()
        {
            return this.userManager.GetUserAsync(HttpContext.User);
        }

        // [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await this
                        .context
                        .Books
                        .Include(book => book.Author)
                        .ToListAsync();

            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // [Route("/books/create")]
        public async Task<IActionResult> Create(Book book)
        {
            var user = await this.GetCurrentUserAsync();

            if (ModelState.IsValid
                && !string.IsNullOrWhiteSpace(book.Title)
                && !string.IsNullOrWhiteSpace(book.Description))
            {
                book.AuthorId = user.Id;
                this.context.Books.Add(book);
                this.context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            // if (id == null) return NotFound();

            var book = await this
                        .context
                        .Books
                        .Include(b => b.Author)
                        .SingleOrDefaultAsync(b => b.Id == id);

            if (book == null) return NotFound();

            return View(book);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // if (id == null) return NotFound();

            var book = await this.context.Books.FindAsync(id);

            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost]
        // [Route("/books/edit/{id}")]
        public async Task<IActionResult> Edit(int id, Book BookEdited)
        {
            if (ModelState.IsValid
                && !string.IsNullOrWhiteSpace(BookEdited.Title)
                && !string.IsNullOrWhiteSpace(BookEdited.Description))
            {
                var bookOld = await this.context.Books.FirstAsync(b => b.Id == id);
                bookOld.Title = BookEdited.Title;
                bookOld.Description = BookEdited.Description;

                this.context.Books.Update(bookOld);
                await this.context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(BookEdited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // if (id == null) return NotFound();

            var book = await this
                        .context
                        .Books
                        .Include(b => b.Author)
                        .SingleOrDefaultAsync(b => b.Id == id);

            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Book book)
        {
            this.context.Books.Remove(book);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Scaffolded stuff
        // private readonly ApplicationDbContext context;

        // private readonly UserManager<ApplicationUser> userManager;

        // private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        // public BooksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        // {
        //     this.context = context;
        //     this.userManager = userManager;
        // }

        // // GET: Books
        // public async Task<IActionResult> Index()
        // {
        //     var applicationDbContext = this.context.Books.Include(b => b.Author);
        //     return View(await applicationDbContext.ToListAsync());
        // }

        // // GET: Books/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var book = await context.Books
        //         .Include(b => b.Author)
        //         .SingleOrDefaultAsync(m => m.Id == id);
        //     if (book == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(book);
        // }

        // // GET: Books/Create
        // public IActionResult Create()
        // {
        //     ViewData["AuthorId"] = new SelectList(context.Users, "Id", "Id");
        //     return View();
        // }

        // // POST: Books/Create
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Title,Description,AuthorId")] Book book)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         ApplicationUser user = await GetCurrentUserAsync();
        //         string id = user.Id;
        //         book.AuthorId = id;

        //         context.Add(book);
        //         await context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["AuthorId"] = new SelectList(context.Users, "Id", "Id", book.AuthorId);
        //     return View(book);
        // }

        // // GET: Books/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var book = await context.Books.SingleOrDefaultAsync(m => m.Id == id);
        //     if (book == null)
        //     {
        //         return NotFound();
        //     }
        //     ViewData["AuthorId"] = new SelectList(context.Users, "Id", "Id", book.AuthorId);
        //     return View(book);
        // }

        // // POST: Books/Edit/5
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Book book)
        // {
        //     if (id != book.Id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             var bookOld = await context.Books.FirstAsync(x => x.Id == id);
        //             bookOld.Title = book.Title;
        //             bookOld.Description = book.Description;

        //             // _context.Attach(book); ???
        //             context.Update(bookOld);
        //             await context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!BookExists(book.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["AuthorId"] = new SelectList(context.Users, "Id", "Id", book.AuthorId);
        //     return View(book);
        // }

        // // GET: Books/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var book = await context.Books
        //         .Include(b => b.Author)
        //         .SingleOrDefaultAsync(m => m.Id == id);
        //     if (book == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(book);
        // }

        // // POST: Books/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var book = await context.Books.SingleOrDefaultAsync(m => m.Id == id);
        //     context.Books.Remove(book);
        //     await context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool BookExists(int id)
        // {
        //     return context.Books.Any(e => e.Id == id);
        // }
        #endregion
    }
}
