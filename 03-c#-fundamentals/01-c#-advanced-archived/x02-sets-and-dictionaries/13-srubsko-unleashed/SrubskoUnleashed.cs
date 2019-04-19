using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _13_srubsko_unleashed
{
    class SrubskoUnleashed
    {
        static void Main()
        {
            var profitBySingerByVenue = new Dictionary<string, Dictionary<string, int>>();
            var concertPattern = @"([A-Za-z ]+) @([A-Za-z ]+) (\d+) (\d+)";

            var input = Console.ReadLine();
            while (input != "End")
            {
                var concertInfo = Regex.Match(input, concertPattern);

                if (concertInfo.Success == false)
                {
                    input = Console.ReadLine();
                    continue;
                }

                var singer = concertInfo.Groups[1].Value;
                var venue = concertInfo.Groups[2].Value;
                var ticketPrice = int.Parse(concertInfo.Groups[3].Value);
                var ticketCount = int.Parse(concertInfo.Groups[4].Value);
                var profit = ticketPrice * ticketCount;

                if (profitBySingerByVenue.ContainsKey(venue) == false)
                {
                    profitBySingerByVenue[venue] = new Dictionary<string, int>();
                }

                if (profitBySingerByVenue[venue].ContainsKey(singer) == false)
                {
                    profitBySingerByVenue[venue][singer] = 0;
                }

                profitBySingerByVenue[venue][singer] += profit;

                input = Console.ReadLine();
            }

            foreach (var venue in profitBySingerByVenue)
            {
                Console.WriteLine(venue.Key);

                var profitBySinger = venue.Value.OrderByDescending(singer => singer.Value);
                foreach (var singer in profitBySinger)
                {
                    Console.WriteLine($"# {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
/*

Lepa Brena @Sunny Beach 25 3500
Dragana @Sunny Beach 23 3500
Ceca @Sunny Beach 28 3500
Mile Kitic @Sunny Beach 21 3500
Ceca @Sunny Beach 35 3500
Ceca @Sunny Beach 70 15000
Saban Saolic @Sunny Beach 120 35000
End

Lepa Brena @Sunny Beach 25 3500
Dragana@Belgrade23 3500
Ceca @Sunny Beach 28 3500
Mile Kitic @Sunny Beach 21 3500
Ceca @Belgrade 35 3500
Ceca @Sunny Beach 70 15000
Saban Saolic @Sunny Beach 120 35000
End

*/
