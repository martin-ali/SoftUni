using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01_most_frequent_number
{
    class MostFrequentNumber
    {
        static void Main()
        {
            var text = File.ReadAllLines("input.txt");

            foreach (var line in text)
            {
                var characters = line.Split();
                var occurrencesByCharacter = new Dictionary<string, int>();

                for (int i = 0; i < characters.Length; i++)
                {
                    var current = characters[i];
                    if (occurrencesByCharacter.ContainsKey(current) == false)
                    {
                        occurrencesByCharacter[current] = 0;
                    }

                    occurrencesByCharacter[current]++;
                }

                var mostFrequentCharacter = occurrencesByCharacter.OrderByDescending(x => x.Value).First().Key;
                File.AppendAllText("output.txt", mostFrequentCharacter + Environment.NewLine);
            }
        }
    }
}
