using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BookLibrary.Models
{
    public class Book
    {
        // [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Book cannot exist without a title.")]
        // [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        // string?
        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}