using System;

namespace _09_index_of_letters
{
    class IndexOfLetters
    {
        static void Main()
        {
            var word = Console.ReadLine();
            for (int i = 0; i < word.Length; i++)
            {
                var character = word[i];
                var characterCode = (int)character - 97;
                Console.WriteLine($"{character} -> {characterCode}");
            }
        }
    }
}
