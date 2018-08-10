namespace CatShop.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Cat
    {

        public Cat() { }

        public Cat(string name, string nickname, double price)
        {
            this.Name = name;
            this.Nickname = nickname;
            this.Price = price;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
