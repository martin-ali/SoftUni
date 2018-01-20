using System;

namespace Identical_Words
{
    class Program
    {
        static void Main()
        {
            var firstWord = Console.ReadLine();
            var secondWord = Console.ReadLine();

            var areTheWordsIdentical = firstWord.ToLower() == secondWord.ToLower();
            Console.WriteLine(areTheWordsIdentical ? "yes" : "no");
        }
    }
}
