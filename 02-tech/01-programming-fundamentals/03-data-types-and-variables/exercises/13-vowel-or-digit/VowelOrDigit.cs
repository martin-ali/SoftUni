using System;

namespace _13_vowel_or_digit
{
    class VowelOrDigit
    {
        static void Main()
        {
            char symbol = char.Parse(Console.ReadLine());

            var symbolIsVowel = "aeiou".Contains(symbol.ToString());
            if (char.IsDigit(symbol))
            {
                Console.WriteLine("digit");
            }
            else if (symbolIsVowel)
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
