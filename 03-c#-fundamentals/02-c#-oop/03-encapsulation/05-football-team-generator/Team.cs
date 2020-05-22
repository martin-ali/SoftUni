namespace _05_football_team_generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private List<Player> players = new List<Player>();

        public Team(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ErrorMessages.NameEmpty);
            }

            this.Name = name;
        }

        public string Name { get; }

        public int Rating
        {
            get
            {
                if (this.players.Count == 0) return 0;

                var rating = 0d;
                foreach (var player in this.players)
                {
                    rating += player.Skill;
                }

                return (int)Math.Round(rating) / this.players.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            var removedPlayers = this.players.RemoveAll(p => p.Name == name);

            if (removedPlayers == 0)
            {
                throw new InvalidOperationException($"Player {name} is not in {this.Name} team.");
            }
        }
    }
}