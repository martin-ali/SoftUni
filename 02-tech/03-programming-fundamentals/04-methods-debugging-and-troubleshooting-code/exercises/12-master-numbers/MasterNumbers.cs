using System;
using System.Linq;

namespace _12_master_numbers
{
    class MasterNumbers
    {
        static void Main()
        {
            var limit = int.Parse(Console.ReadLine());

            for (int currentNumber = 1; currentNumber <= limit; currentNumber++)
            {
                if (ContainsEvenDigit(currentNumber)
                    && SumOfDigits(currentNumber) % 7 == 0
                    && IsPalindrome(currentNumber))
                {
                    Console.WriteLine(currentNumber);
                }
            }
        }

        private static bool IsPalindrome(int number)
        {
            var numberString = number.ToString();
            return numberString.SequenceEqual(numberString.Reverse());
        }

        private static int SumOfDigits(int number)
        {
            var sum = 0;
            while (number > 0)
            {
                sum += (number % 10);
                number /= 10;
            }

            return sum;
        }

        private static bool ContainsEvenDigit(int number)
        {
            while (number > 0)
            {
                if (number % 2 == 0)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
