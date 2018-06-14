using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_softuni_karaoke
{
    class SoftUniKaraoke
    {
        static void Main()
        {
            #if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
            #endif

            const string Separator = @",\s*";
            var listedPerformers = Regex.Split(Console.ReadLine(), Separator);
            var listedSongs = Regex.Split(Console.ReadLine(), Separator);
            var awardsByPerformer = new Dictionary<string, HashSet<string>>();

            var input = Console.ReadLine();
            while (input != "dawn")
            {
                var performanceInfo = Regex.Split(input, Separator);
                var performer = performanceInfo[0];
                var song = performanceInfo[1];
                var award = performanceInfo[2];

                if (listedPerformers.Contains(performer) && listedSongs.Contains(song))
                {
                    if (awardsByPerformer.ContainsKey(performer) == false)
                    {
                        awardsByPerformer[performer] = new HashSet<string>();
                    }

                    awardsByPerformer[performer].Add(award);
                }

                input = Console.ReadLine();
            }

            if (awardsByPerformer.Count > 0)
            {
                var orderedAwardsByPerformer = awardsByPerformer
                                            .OrderByDescending(p => p.Value.Count)
                                            .ThenBy(p => p.Key);

                foreach (var performer in orderedAwardsByPerformer)
                {
                    Console.WriteLine($"{performer.Key}: {performer.Value.Count} awards");

                    var awards = performer.Value.OrderBy(a => a);
                    foreach (var award in awards)
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
}