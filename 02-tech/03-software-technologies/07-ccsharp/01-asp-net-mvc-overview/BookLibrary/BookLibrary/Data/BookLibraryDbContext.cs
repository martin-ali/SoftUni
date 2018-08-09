using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Models;

namespace BookLibrary.Data
{
    public class BookLibraryDbContext : IdentityDbContext<User>
    {
        public BookLibraryDbContext(DbContextOptions<BookLibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder
            //     .Entity<Book>()
            //     .HasOne(book => book.Author)
            //     .WithMany(user => user.Books)
            //     .HasForeignKey(book => book.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}
