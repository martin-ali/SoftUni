using System;

namespace _05_word_in_plural
{
    class WordToPlural
    {
        static void Main()
        {
            var word = Console.ReadLine();
            var pluralizedWord = string.Empty;

            if (word.EndsWith("y"))
            {
                pluralizedWord = word.Remove(word.Length - 1) + "ies";
            }
            else if (word.EndsWith("o")
                    || word.EndsWith("s")
                    || word.EndsWith("x")
                    || word.EndsWith("z")
                    || word.EndsWith("ch")
                    || word.EndsWith("sh"))
            {
                pluralizedWord = word + "es";
            }
            else
            {
                pluralizedWord = word + 's';
            }

            Console.WriteLine(pluralizedWord);
        }
    }
}
