using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class ArticleViewModel
    {
        public ArticleViewModel(int id, string title, string content, string authorId)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.AuthorId = authorId;
        }

        public ArticleViewModel() { }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
