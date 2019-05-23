using System;
using System.Collections.Generic;

namespace _05_count_symbols
{
    class CountSymbols
    {
        static void Main()
        {
            var text = Console.ReadLine();
            var occurrencesByCharacter = new SortedDictionary<char, int>();
            for (int index = 0; index < text.Length; index++)
            {
                var character = text[index];

                if (occurrencesByCharacter.ContainsKey(character) == false)
                {
                    occurrencesByCharacter[character] = 0;
                }

                occurrencesByCharacter[character]++;
            }

            foreach (var characterInfo in occurrencesByCharacter)
            {
                Console.WriteLine($"{characterInfo.Key}: {characterInfo.Value} time/s");
            }
        }
    }
}
