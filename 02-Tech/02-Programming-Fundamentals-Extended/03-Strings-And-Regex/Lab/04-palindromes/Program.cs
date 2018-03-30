using System;
using System.Collections.Generic;

namespace _04_palindromes
{
    class Program
    {
        static void Main()
        {
            var text = Console.ReadLine();
            var words = text.Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            var palindromes = new SortedSet<string>();

            foreach (var word in words)
            {
                if (IsPalindrome(word))
                {
                    palindromes.Add(word);
                }
            }

            Console.WriteLine(String.Join(", ", palindromes));
        }

        private static bool IsPalindrome(string word)
        {
            int length = word.Length / 2;
            for (int start = 0, end = word.Length - 1; start < length; start++, end--)
            {
                if (word[start] != word[end]) return false;
            }

            return true;
        }
    }
}
