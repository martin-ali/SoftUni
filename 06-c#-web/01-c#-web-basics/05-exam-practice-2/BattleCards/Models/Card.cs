using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BattleCards.Common;

namespace BattleCards.Models
{
    public class Card
    {
        public Card() { }

        public Card(string name, string imageUrl, string keyword, int attack, int health, string description)
        {
            this.Name = name;
            this.ImageUrl = imageUrl;
            this.Keyword = keyword;
            this.Attack = attack;
            this.Health = health;
            this.Description = description;
        }

        public int Id { get; set; }

        [Required]
        [MinLength(Constants.CardNameMinLength)]
        [MaxLength(Constants.CardNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        [Required]
        public int Attack { get; set; }

        [Required]
        public int Health { get; set; }

        [Required]
        [MaxLength(Constants.CardDescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}