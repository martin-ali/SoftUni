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

        // [Required]
        // [MaxLength(50)]
        public string Title { get; set; }

        // [Required]
        public string Description { get; set; }

        // string?
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }
    }
}