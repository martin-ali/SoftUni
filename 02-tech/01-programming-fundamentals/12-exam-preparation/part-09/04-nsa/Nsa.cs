using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_nsa
{
    class Nsa
    {
        static void Main()
        {
            var spyNetwork = new Dictionary<string, Dictionary<string, int>>();

            while (ProgramShouldContinue(out string input))
            {
                var info = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                var country = info[0];
                var spy = info[1];
                var serviceDays = int.Parse(info[2]);

                if (spyNetwork.ContainsKey(country) == false)
                {
                    spyNetwork[country] = new Dictionary<string, int>();
                }

                if (spyNetwork[country].ContainsKey(spy) == false)
                {
                    spyNetwork[country][spy] = 0;
                }

                spyNetwork[country][spy] = serviceDays;
            }

            var orderedSpyNetwork = spyNetwork.OrderByDescending(country => country.Value.Count);
            foreach (var country in orderedSpyNetwork)
            {
                Console.WriteLine($"Country: {country.Key}");
                var orderedSpies = country.Value.OrderByDescending(spy => spy.Value);
                foreach (var spy in orderedSpies)
                {
                    Console.WriteLine($"**{spy.Key} : {spy.Value}");
                }
            }
        }

        private static bool ProgramShouldContinue(out string result)
        {
            var input = Console.ReadLine();

            if (input == "quit")
            {
                result = null;
                return false;
            }

            result = input;
            return true;
        }
    }
}
/*

Germany -> Duffy -> 1
Australia -> Bond -> 7
America -> Bond -> 5
Germany -> Alex -> 4
America -> Donald -> 4
Germany -> Jeffrey -> 3
Australia -> Jeffrey -> 4
quit

 */
