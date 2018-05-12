using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _10_srubsko_unleashed
{
    class SrubskoUnleashed
    {
        // Could be done with non-capturing group
        private static string inputPattern = @"^(.+) (@.+?) (\d+) (\d+)$";

        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
            #endif


            var singersAndProfitsByVenue = new Dictionary<string, Dictionary<string, long>>();
            var line = Console.ReadLine();
            while (line != "End")
            {
                var concert = Regex.Matches(line, inputPattern);
                foreach (Match parameter in concert)
                {
                    var singer = parameter.Groups[1].ToString();
                    var venue = parameter.Groups[2].ToString();
                    var ticketPrice = int.Parse(parameter.Groups[3].ToString());
                    var ticketsCount = int.Parse(parameter.Groups[4].ToString());
                    var profits = ticketPrice * ticketsCount;

                    if (singersAndProfitsByVenue.ContainsKey(venue) == false)
                    {
                        singersAndProfitsByVenue[venue] = new Dictionary<string, long>();
                    }

                    if (singersAndProfitsByVenue[venue].ContainsKey(singer) == false)
                    {
                        singersAndProfitsByVenue[venue][singer] = 0;
                    }

                    singersAndProfitsByVenue[venue][singer] += profits;
                }

                line = Console.ReadLine();
            }

            foreach (var venue in singersAndProfitsByVenue)
            {
                Console.WriteLine($"{venue.Key.Substring(1)}");
                var sortedSingers = venue.Value.OrderByDescending(x => x.Value);
                foreach (var singer in sortedSingers)
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
