using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03_count_of_symbols
{
    class CountOfSymbols
    {
        static void Main()
        {
            var text = File.ReadAllText("input.txt");
            var occurrencesByLetter = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                var current = text[i];

                if (occurrencesByLetter.ContainsKey(current) == false)
                {
                    occurrencesByLetter[current] = 0;
                }

                occurrencesByLetter[current]++;
            }

            foreach (var letter in occurrencesByLetter.OrderByDescending(l => l.Value))
            {
                File.AppendAllText("output.txt", $"{letter.Key} -> {letter.Value}{Environment.NewLine}");
            }
        }
    }
}
