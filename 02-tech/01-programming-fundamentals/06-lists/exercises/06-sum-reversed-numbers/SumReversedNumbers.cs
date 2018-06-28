using System;
using System.Linq;

namespace _06_sum_reversed_numbers
{
    class SumReversedNumbers
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var reversedDigitsElementsSum = elements.Select(x => ReverseDigits(x)).Sum();

            Console.WriteLine(reversedDigitsElementsSum);
        }

        private static int ReverseDigits(int number)
        {
            var reversedNumber = 0;
            var position = (int)Math.Pow(10, number.ToString().Length - 1);
            while (number > 0)
            {
                var digit = (number % 10);
                reversedNumber += (digit * position);
                number /= 10;
                position /= 10;
            }

            return reversedNumber;
        }
    }
}
/*

123 234 12
12 12 34 84 66 12
120 1200 12000

 */
