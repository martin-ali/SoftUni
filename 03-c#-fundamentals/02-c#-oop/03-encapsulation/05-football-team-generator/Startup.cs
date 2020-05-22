using System;

namespace _05_football_team_generator
{
    class Startup
    {
        static void Main()
        {
            var manager = new TeamsManager();

            var input = Console.ReadLine();
            while (input != "END")
            {
                try
                {
                    var parameters = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    var command = parameters[0];
                    var teamName = parameters[1];

                    if (command == "Team")
                    {
                        manager.AddTeam(teamName);
                    }
                    else if (command == "Add")
                    {
                        var playerName = parameters[2];
                        var endurance = int.Parse(parameters[3]);
                        var sprint = int.Parse(parameters[4]);
                        var dribble = int.Parse(parameters[5]);
                        var passing = int.Parse(parameters[6]);
                        var shooting = int.Parse(parameters[7]);

                        manager.AddPlayerToTeam(teamName, playerName, endurance, sprint, dribble, passing, shooting);
                    }
                    else if (command == "Remove")
                    {
                        var playerName = parameters[2];

                        manager.RemovePlayerFromTeam(teamName, playerName);
                    }
                    else if (command == "Rating")
                    {
                        var rating = manager.GetRating(teamName);

                        Console.WriteLine($"{teamName} - {rating}");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
