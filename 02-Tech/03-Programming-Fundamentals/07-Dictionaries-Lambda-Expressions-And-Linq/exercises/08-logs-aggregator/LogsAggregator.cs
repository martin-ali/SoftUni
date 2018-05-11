using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08_logs_aggregator
{
    class LogsAggregator
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
            #endif

            var numberOfLines = int.Parse(Console.ReadLine());

            var ipsByUser = new SortedDictionary<string, HashSet<string>>();
            var sessionDurationsByUser = new Dictionary<string, int>();
            for (int i = 0; i < numberOfLines; i++)
            {
                var line = Console.ReadLine().Split(' ');
                var ip = line[0];
                var user = line[1];
                var duration = int.Parse(line[2]);

                if (ipsByUser.ContainsKey(user) == false)
                {
                    ipsByUser[user] = new HashSet<string>();
                }

                if (sessionDurationsByUser.ContainsKey(user) == false)
                {
                    sessionDurationsByUser[user] = 0;
                }

                ipsByUser[user].Add(ip);
                sessionDurationsByUser[user] += duration;
            }

            foreach (var user in ipsByUser)
            {
                var sortedIps = user.Value.OrderBy(x => x);
                Console.WriteLine($"{user.Key}: {sessionDurationsByUser[user.Key]} [{string.Join(", ", sortedIps)}]");
            }
        }
    }
}
