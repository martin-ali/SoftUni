using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03_word_count
{
    class WordCount
    {
        static void Main()
        {
            var words = File.ReadAllText("text.txt")
                            .Split(new[] { ' ', '-', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToLookup(k => k.ToLower(), v => v);

            var occurrencesByWord = File.ReadAllLines("words.txt")
                                        .ToDictionary(k => k.ToLower(), v => words[v.ToLower()].Count())
                                        .OrderByDescending(w => w.Value)
                                        .Select(w => $"{w.Key} - {w.Value}");

            File.WriteAllLines("actualResult.txt", occurrencesByWord);
        }
    }
}
