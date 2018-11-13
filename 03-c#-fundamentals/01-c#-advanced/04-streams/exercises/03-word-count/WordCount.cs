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
            var occurrencesByWord = new Dictionary<string, int>();
            using (var wordReader = new StreamReader("words.txt"))
            {
                while (wordReader.EndOfStream == false)
                {
                    occurrencesByWord[wordReader.ReadLine().ToLower()] = 0;
                }
            }

            using (var textReader = new StreamReader("text.txt"))
            {
                var text = textReader.ReadToEnd()
                            .ToLower()
                            .Split("-,.?! \r\n…".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in text)
                {
                    if (occurrencesByWord.ContainsKey(word))
                    {
                        occurrencesByWord[word]++;
                    }
                }
            }

            using (var writer = new StreamWriter("result.txt"))
            {
                foreach (var word in occurrencesByWord.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
