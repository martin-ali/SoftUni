using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_ranking
{
    class Ranking
    {
        static void Main()
        {
            var passwordByContest = new Dictionary<string, string>();
            var contestsByUser = new SortedDictionary<string, HashSet<string>>();
            var pointsBySubmission = new Dictionary<string, int>();

            // Contests input
            var contestInput = Console.ReadLine();
            while (contestInput != "end of contests")
            {
                var inputData = contestInput.Split(':');
                var contest = inputData[0];
                var password = inputData[1];

                passwordByContest[contest] = password;

                contestInput = Console.ReadLine();
            }

            // Submissions input
            var submissionInput = Console.ReadLine();
            while (submissionInput != "end of submissions")
            {
                var inputData = submissionInput.Split("=>");
                var contest = inputData[0];
                var password = inputData[1];
                var username = inputData[2];
                var points = int.Parse(inputData[3]);

                if (passwordByContest.ContainsKey(contest) && passwordByContest[contest] == password)
                {
                    if (contestsByUser.ContainsKey(username) == false)
                    {
                        contestsByUser[username] = new HashSet<string>();
                    }

                    if (contestsByUser[username].Contains(contest) == false)
                    {
                        contestsByUser[username].Add(contest);
                    }

                    var submission = $"{contest}{username}";
                    if (pointsBySubmission.ContainsKey(submission) == false || pointsBySubmission[submission] < points)
                    {
                        pointsBySubmission[submission] = points;
                    }
                }

                submissionInput = Console.ReadLine();
            }

            // Process
            var bestScoreUser = contestsByUser
                                .Select(u =>
                                {
                                    var contests = u.Value;
                                    var totalPoints = contests.Select(c => pointsBySubmission[$"{c}{u.Key}"]).Sum();
                                    return (name: u.Key, points: totalPoints);
                                })
                                .OrderByDescending(u => u.points)
                                .First();

            // Output
            Console.WriteLine($"Best candidate is {bestScoreUser.name} with total {bestScoreUser.points} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in contestsByUser)
            {
                Console.WriteLine(user.Key);
                var contests = user.Value.OrderByDescending(c => pointsBySubmission[$"{c}{user.Key}"]);
                foreach (var contest in contests)
                {
                    var submission = $"{contest}{user.Key}";
                    Console.WriteLine($"#  {contest} -> {pointsBySubmission[submission]}");
                }
            }
        }
    }
}