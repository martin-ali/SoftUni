using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_most_frequent_number
{
    class MostFrequentNumber
    {
        static void Main()
        {
            var elements = Console
                           .ReadLine()
                           .Split(' ')
                           .Select(int.Parse)
                           .ToList();

            var occurrences = new Dictionary<int, int>();
            for (int i = 0; i < elements.Count; i++)
            {
                var current = elements[i];
                if (occurrences.ContainsKey(current) == false)
                {
                    occurrences[current] = 0;
                }

                occurrences[current]++;
            }

            var mostFrequentElement = occurrences.Aggregate((mostFrequent, candidate) => (candidate.Value > mostFrequent.Value ? candidate : mostFrequent));
            Console.WriteLine(mostFrequentElement.Key);
        }
    }
}
/*

4 1 1 4 2 3 4 4 1 2 4 9 3
2 2 2 2 1 2 2 2
7 7 7 0 2 2 2 0 10 10 10

 */
