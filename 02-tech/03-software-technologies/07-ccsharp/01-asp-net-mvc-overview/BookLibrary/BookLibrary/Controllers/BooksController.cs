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
using Microsoft.AspNetCore.Authorization;

namespace BookLibrary.Controllers
{
    // [Route("/Books")]
    public class BooksController : Controller
    {
        #region My code
        private readonly BookLibraryDbContext context;

        private readonly UserManager<User> userManager;

        public BooksController(BookLibraryDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public Task<User> GetCurrentUserAsync()
        {
            return this.userManager.GetUserAsync(HttpContext.User);
        }

        [HttpGet]
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
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        // [Route("/books/create")]
        public async Task<IActionResult> Create(Book book)  // BookViewModel
        {
            var user = await this.GetCurrentUserAsync();

            if (ModelState.IsValid == false)
            {
                return View(book);
            }

            book.AuthorId = user.Id;
            this.context.Books.Add(book);
            this.context.SaveChanges();

            // return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Details), new { book.Id });
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
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            // if (id == null) return NotFound();

            var book = await this.context.Books.FindAsync(id);

            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost]
        [Authorize]
        // [Route("/books/edit/{id}")]
        public async Task<IActionResult> Edit(int id, Book BookEdited)
        {
            if (ModelState.IsValid == false)
            {
                return View(BookEdited);
            }

            var bookOld = await this.context.Books.FirstAsync(b => b.Id == id);
            bookOld.Title = BookEdited.Title;
            bookOld.Description = BookEdited.Description;

            this.context.Books.Update(bookOld);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Delete(Book book)
        {
            this.context.Books.Remove(book);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Scaffolded stuff
        // private readonly ApplicationDbContext context;

        // private readonly UserManager<User> userManager;

        // private Task<User> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        // public BooksController(ApplicationDbContext context, UserManager<User> userManager)
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
        //         User user = await GetCurrentUserAsync();
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
