using System;
using System.Linq;
using System.Collections.Generic;

namespace _01_odd_occurrences
{
    class Program
    {
        static void Main()
        {
            var wordOccurrences = new Dictionary<string, int>();
            var words = Console
                        .ReadLine()
                        .ToLower()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (wordOccurrences.ContainsKey(word) == false)
                {
                    wordOccurrences[word] = 0;
                }

                wordOccurrences[word]++;
            }

            var wordsWithOddOccurrences = wordOccurrences
                                            .Where(x => x.Value % 2 != 0)
                                            .Select(x => x.Key);
            Console.WriteLine(String.Join(", ", wordsWithOddOccurrences));
        }
    }
}