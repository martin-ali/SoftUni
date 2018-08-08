using System;
using Microsoft.AspNetCore.Identity;

namespace BookLibrary.Models
{
    public class Book
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        // string?
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }
    }
}