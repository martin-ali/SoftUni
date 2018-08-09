using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class CommentViewModel
    {
        public CommentViewModel() { }

        public CommentViewModel(int id, string content, string authorId)
        {
            this.Id = id;
            this.AuthorId = authorId;
            this.Content = content;
            this.DateAdded = DateTime.Now;

        }

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public int ArticleId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
