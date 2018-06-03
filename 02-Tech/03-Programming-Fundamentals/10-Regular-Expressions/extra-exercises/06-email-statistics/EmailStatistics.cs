using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06_email_statistics
{
    class EmailStatistics
    {
        private const string username = @"[A-Za-z]{5,}";

        private const string server = @"[a-z]{3,}";

        private const string topLevelDomain = @".(com|bg|org)";

        static void Main()
        {
            var usernamesByDomain = new Dictionary<string, HashSet<string>>();

            var numberOfEmails = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEmails; i++)
            {
                var emailMatch = Regex.Match(Console.ReadLine(), $"^({username})@({server}{topLevelDomain})$");
                if (emailMatch.Success)
                {
                    var username = emailMatch.Groups[1].Value;
                    var domain = emailMatch.Groups[2].Value;

                    if (usernamesByDomain.ContainsKey(domain) == false)
                    {
                        usernamesByDomain[domain] = new HashSet<string>();
                    }

                    usernamesByDomain[domain].Add(username);
                }
            }

            var orderedUsernamesByDomain = usernamesByDomain.OrderByDescending(dom => dom.Value.Count());
            foreach (var domain in orderedUsernamesByDomain)
            {
                Console.WriteLine($"{domain.Key}:");
                foreach (var username in domain.Value)
                {
                    Console.WriteLine($"### {username}");
                }
            }
        }
    }
}
/*

5
Pesho@abv.bg
JohnDowe@gmail.com
Maria@gmail.com
invalid123@dir.bg
nakov@yahoo.com

5
Georgi@abv.bg
Petran@gmail.com
Vladi@gmail.com
super_man@abv.bg
superMan@abv.bg

 */
