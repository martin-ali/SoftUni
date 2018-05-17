using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _09_teamwork_projects
{
    class TeamworkProjects
    {
        static void Main()
        {
#if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
#endif

            var teamsByName = new SortedDictionary<string, Team>();
            var numberOfTeams = int.Parse(Console.ReadLine());
            var input = new string[1];
            for (int i = 0; i < numberOfTeams; i++)
            {
                input = Console.ReadLine().Split('-');
                var user = input[0];
                var team = input[1];

                if (teamsByName.ContainsKey(team))
                {
                    Console.WriteLine($"Team {team} was already created!");
                }
                else if (teamsByName.Any(t => t.Value.Creator == user))
                {
                    Console.WriteLine($"{user} cannot create another team!");
                }
                else
                {
                    teamsByName[team] = new Team(user, team);
                    Console.WriteLine($"Team {team} has been created by {user}!");
                }
            }

            input = Console.ReadLine().Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "end of assignment")
            {
                var user = input[0];
                var team = input[1];

                if (teamsByName.ContainsKey(team) == false)
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (teamsByName.Any(t => t.Value.Members.Contains(user) || t.Value.Creator == user))
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                }
                else
                {
                    teamsByName[team].Members.Add(user);
                }

                input = Console.ReadLine().Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
            }

            var validTeams = teamsByName
                                .Where(team => team.Value.Members.Count > 0)
                                .OrderByDescending(team => team.Value.Members.Count);

            foreach (var team in validTeams)
            {
                Console.WriteLine(team.Key);
                Console.WriteLine($"- {team.Value.Creator}");
                foreach (var member in team.Value.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            var teamsToDisband = teamsByName
                                    .Where(team => team.Value.Members.Count == 0)
                                    .OrderByDescending(team => team.Value.Members.Count);

            foreach (var team in teamsToDisband)
            {
                Console.WriteLine(team.Key);
            }
        }
    }

    internal class Team
    {
        public Team(string creator, string name)
        {
            this.Creator = creator;
            this.Name = name;
        }

        public string Creator { get; private set; }

        public string Name { get; private set; }

        public List<string> Members { get; private set; } = new List<string>();
    }
}
