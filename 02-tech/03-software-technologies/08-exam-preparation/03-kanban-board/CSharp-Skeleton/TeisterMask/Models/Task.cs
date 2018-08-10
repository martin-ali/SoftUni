namespace TeisterMask.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required]
        public string Status { get; set; }

        public Task() { }

        public Task(string title, string status)
        {
            this.Title = title;
            this.Status = status;
        }
    }
}
