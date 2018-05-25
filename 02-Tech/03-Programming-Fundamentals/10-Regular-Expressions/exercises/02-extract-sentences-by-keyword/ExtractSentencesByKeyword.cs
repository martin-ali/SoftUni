using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_extract_sentences_by_keyword
{
    class ExtractSentencesByKeyword
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("test.txt"));
            #endif

            var keyword = Console.ReadLine();
            var sentences = Console.ReadLine().Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            var SentencesContainingKeyword = sentences.Where(sentence => Regex.IsMatch(sentence, $"\\b{keyword}\\b"));
            foreach (var sentence in SentencesContainingKeyword)
            {
                Console.WriteLine(sentence);
            }
        }
    }
}