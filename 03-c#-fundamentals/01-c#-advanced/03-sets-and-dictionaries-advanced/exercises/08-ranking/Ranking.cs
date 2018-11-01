using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08_ranking
{
    class Ranking
    {
        private const string CONTESTS_END = "end of contests";
        private const string SUBMISSIONS_END = "end of submissions";

        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
#endif

            var passwordByContest = new Dictionary<string, string>();

            var input = Console.ReadLine();
            while (input != CONTESTS_END)
            {
                var data = input.Split(':');
                var contest = data[0];
                var password = data[1];

                passwordByContest[contest] = password;

                input = Console.ReadLine();
            }

            var pointsByContestByUser = new SortedDictionary<string, Dictionary<string, int>>();
            input = Console.ReadLine();
            while (input != SUBMISSIONS_END)
            {
                var data = input.Split("=>");
                var contest = data[0];
                var password = data[1];
                var username = data[2];
                var points = int.Parse(data[3]);

                if (passwordByContest.ContainsKey(contest)
                    && passwordByContest[contest] == password)
                {
                    if (pointsByContestByUser.ContainsKey(username) == false)
                    {
                        pointsByContestByUser[username] = new Dictionary<string, int>();
                    }

                    if (pointsByContestByUser[username].ContainsKey(contest) == false)
                    {
                        pointsByContestByUser[username][contest] = 0;
                    }

                    if (pointsByContestByUser[username][contest] < points)
                    {
                        pointsByContestByUser[username][contest] = points;
                    }
                }

                input = Console.ReadLine();
            }

            var bestCandidate = pointsByContestByUser.Aggregate((bestUser, user) => (user.Value.Sum(us => us.Value) > bestUser.Value.Sum(us => us.Value) ? user : bestUser)).Key;

            Console.WriteLine($"Best candidate is {bestCandidate} with total {pointsByContestByUser[bestCandidate].Sum(us => us.Value)} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in pointsByContestByUser)
            {
                Console.WriteLine($"{user.Key}");

                foreach (var contest in user.Value.OrderByDescending(con => con.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
