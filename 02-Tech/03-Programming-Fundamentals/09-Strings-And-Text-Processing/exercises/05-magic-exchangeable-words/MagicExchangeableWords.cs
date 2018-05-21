using System;
using System.Linq;

namespace _05_magic_exchangeable_words
{
    class MagicExchangeableWords
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var first = input[0];
            var second = input[1];

            var wordsAreExchangeable = first.Distinct().Count() == second.Distinct().Count();
            Console.WriteLine(wordsAreExchangeable.ToString().ToLower());
        }
    }
}
