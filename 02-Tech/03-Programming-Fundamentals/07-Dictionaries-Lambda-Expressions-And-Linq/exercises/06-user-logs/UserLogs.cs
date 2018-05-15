using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _06_user_logs
{
    class UserLogs
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
            #endif

            var delimiters = new string[] { "IP=", "message=", "user=", " " };
            var usersAndIpAccessCount = new SortedDictionary<string, Dictionary<string, int>>();

            var parameters = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            while (parameters[0] != "end")
            {
                var ip = parameters[0];
                var user = parameters[2];

                if (usersAndIpAccessCount.ContainsKey(user) == false)
                {
                    usersAndIpAccessCount[user] = new Dictionary<string, int>();
                }

                if (usersAndIpAccessCount[user].ContainsKey(ip) == false)
                {
                    usersAndIpAccessCount[user][ip] = 0;
                }

                usersAndIpAccessCount[user][ip]++;

                parameters = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var user in usersAndIpAccessCount)
            {
                Console.WriteLine($"{user.Key}:");
                var ipsWithAccessCount = user.Value.Select(ip => $"{ip.Key} => {ip.Value}");
                Console.WriteLine($"{string.Join(", ", ipsWithAccessCount)}.");
            }
        }
    }
}
