using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Comment
    {
        public Comment() { }

        public Comment(string content, string authorId, int articleId)
        {
            this.Content = content;
            this.AuthorId = authorId;
            this.ArticleId = articleId;
            this.DateAdded = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        public Article Article { get; set; }

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
