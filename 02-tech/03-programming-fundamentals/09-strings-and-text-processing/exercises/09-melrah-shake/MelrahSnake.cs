using System;
using System.IO;

namespace _09_melrah_shake
{
    class MelrahSnake
    {
        static void Main()
        {
            #if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
            #endif

            var characters = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (true)
            {
                var firstMatchIndex = characters.IndexOf(pattern);
                var lastMatchIndex = characters.LastIndexOf(pattern);

                if (firstMatchIndex >= lastMatchIndex || pattern == string.Empty)
                {
                    Console.WriteLine("No shake.");
                    break;
                }

                characters = characters.Remove(lastMatchIndex, pattern.Length);
                characters = characters.Remove(firstMatchIndex, pattern.Length);
                pattern = pattern.Remove(pattern.Length / 2, 1);

                Console.WriteLine("Shaked it.");
            }

            Console.WriteLine(characters);
        }
    }
}
