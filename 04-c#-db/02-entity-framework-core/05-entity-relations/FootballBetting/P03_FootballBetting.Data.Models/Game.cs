using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        public int HomeTeamId { get; set; }

        [ForeignKey("HomeTeamId")]
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        [ForeignKey("AwayTeamId")]
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public decimal HomeTeamBetRate { get; set; }

        public decimal AwayTeamBetRate { get; set; }

        public decimal DrawBetRate { get; set; }

        public decimal Result { get; set; }

        public ICollection<Bet> Bets { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}