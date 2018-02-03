using System;
using System.Linq;

namespace Vowels_Sum
{
    class Program
    {
        private static char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        static void Main()
        {
            var word = Console.ReadLine().ToLower().ToCharArray();

            var numberOfVowels = 0;

            foreach (char character in word)
            {
                if (vowels.Contains(character))
                {
                    numberOfVowels += Array.IndexOf(vowels, character) + 1;
                }
            }

            Console.WriteLine(numberOfVowels);
        }
    }
}
