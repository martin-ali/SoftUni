using System;
using System.Collections.Generic;

namespace _11_logs_aggregator
{
    class LogsAggregator
    {
        static void Main()
        {
            var sessionDurationByUser = new SortedDictionary<string, int>();
            var uniqueIpsByUser = new Dictionary<string, HashSet<string>>();

            var logCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < logCount; i++)
            {
                var logData = Console.ReadLine().Split();
                var ip = logData[0];
                var user = logData[1];
                var sessionDuration = int.Parse(logData[2]);

                if (sessionDurationByUser.ContainsKey(user) == false)
                {
                    sessionDurationByUser[user] = 0;
                    uniqueIpsByUser[user] = new HashSet<string>();
                }

                sessionDurationByUser[user] += sessionDuration;
                uniqueIpsByUser[user].Add(ip);
            }

            foreach (var sessionDuration in sessionDurationByUser)
            {
                var uniqueIps = string.Join(", ", uniqueIpsByUser[sessionDuration.Key]);
                Console.WriteLine($"{sessionDuration.Key}: {sessionDuration.Value} [{uniqueIps}]");
            }
        }
    }
}
/*

7
192.168.0.11 peter 33
10.10.17.33 alex 12
10.10.17.35 peter 30
10.10.17.34 peter 120
10.10.17.34 peter 120
212.50.118.81 alex 46
212.50.118.81 alex 4

*/
