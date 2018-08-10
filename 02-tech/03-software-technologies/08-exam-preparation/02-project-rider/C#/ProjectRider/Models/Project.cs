
namespace ProjectRider.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        public Project() { }

        public Project(string title, string description, int budget)
        {
            this.Title = title;
            this.Description = description;
            this.Budget = budget;
        }

        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        [Required]
        public int Budget { get; set; }


    }
}
