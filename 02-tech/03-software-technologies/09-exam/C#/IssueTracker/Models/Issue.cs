namespace IssueTracker.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Issue
    {
        public Issue() { }

        public Issue(string title, string content, int priority)
        {
            this.Title = title;
            this.Content = content;
            this.Priority = priority;
        }

        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        [Required]
        public int Priority { get; set; }
    }
}
