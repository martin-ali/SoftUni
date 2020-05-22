namespace _05_football_team_generator
{
    using System;
    using System.Collections.Generic;

    public class TeamsManager
    {
        public Dictionary<string, Team> teamByName { get; } = new Dictionary<string, Team>();

        private void ThrowIfTeamDoesntExist(string teamName)
        {
            if (this.teamByName.ContainsKey(teamName) == false)
            {
                throw new InvalidOperationException($"Team {teamName} does not exist.");
            }
        }

        public void AddTeam(string name)
        {
            this.teamByName[name] = new Team(name);
        }

        public void AddPlayerToTeam(string teamName, string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            ThrowIfTeamDoesntExist(teamName);

            var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            var team = this.teamByName[teamName];

            team.AddPlayer(player);
        }

        public void RemovePlayerFromTeam(string teamName, string playerName)
        {
            ThrowIfTeamDoesntExist(teamName);

            var team = this.teamByName[teamName];

            team.RemovePlayer(playerName);
        }

        public int GetRating(string teamName)
        {
            ThrowIfTeamDoesntExist(teamName);

            return this.teamByName[teamName].Rating;
        }
    }
}