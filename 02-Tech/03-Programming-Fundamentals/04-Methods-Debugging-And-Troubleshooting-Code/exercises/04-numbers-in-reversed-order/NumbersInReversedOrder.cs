using System;

namespace _04_numbers_in_reversed_order
{
    class NumbersInReversedOrder
    {
        static void Main()
        {
            var numberString = Console.ReadLine();
            var reversedNumberString = Reverse(numberString);
            Console.WriteLine(reversedNumberString);
        }

        private static string Reverse(string stringToReverse)
        {
            var reversedString = string.Empty;
            for (int character = stringToReverse.Length - 1; character >= 0; character--)
            {
                reversedString += stringToReverse[character];
            }

            return reversedString;
        }
    }
}
