using System;

namespace _03_unicode_characters
{
    class UnicodeCharacters
    {
        static void Main()
        {
            var input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(GetUnicodeRepresentation(input[i]).ToLower());
            }
            Console.WriteLine();
        }

        static string GetUnicodeRepresentation(char symbol)
        {
            return $"\\u{(int)symbol:X4}";
        }

    }
}
