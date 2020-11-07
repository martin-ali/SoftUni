namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        [Column(TypeName = "char(3)")]
        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        [ForeignKey("PrimaryKitColorId")]
        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }

        [ForeignKey("SecondaryKitColorId")]
        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }

        [ForeignKey("TownId")]
        public Town Town { get; set; }

        public ICollection<Game> HomeGames { get; set; }

        public ICollection<Game> AwayGames { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}