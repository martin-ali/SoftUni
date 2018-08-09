using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Article
    {
        public Article() { }

        public Article(string title, string content, string authorId)
        {
            this.Title = title;
            this.Content = content;
            this.AuthorId = authorId;
            this.DateAdded = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public IList<Comment> Comments { get; set; } = new List<Comment>();

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsAuthor(string name)
        {
            return this.Author.UserName == name;
        }
    }
}
