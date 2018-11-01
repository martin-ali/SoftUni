using System;
using System.Collections.Generic;

namespace _04_count_symbols
{
    class ContSymbols
    {
        static void Main()
        {
            var text = Console.ReadLine();
            var occurrencesBySymbol = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                var symbol = text[i];

                if (occurrencesBySymbol.ContainsKey(symbol) == false)
                {
                    occurrencesBySymbol[symbol] = 0;
                }

                occurrencesBySymbol[symbol]++;
            }

            foreach (var occurrence in occurrencesBySymbol)
            {
                Console.WriteLine($"{occurrence.Key}: {occurrence.Value} time/s");
            }
        }
    }
}
