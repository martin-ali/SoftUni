using System;
using System.Collections.Generic;

namespace _01_reverse_strings
{
    class ReverseStrings
    {
        static void Main()
        {
            var text = Console.ReadLine();
            var reversedText = new Stack<char>(text);

            foreach (var character in reversedText)
            {
                Console.Write(character);
            }
        }
    }
}
