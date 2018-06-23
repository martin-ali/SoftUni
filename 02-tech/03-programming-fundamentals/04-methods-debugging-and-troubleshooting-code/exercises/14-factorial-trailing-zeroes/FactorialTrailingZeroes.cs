using System;
using System.Numerics;

namespace _14_factorial_trailing_zeroes
{
    class FactorialTrailingZeroes
    {
        static void Main()
        {
            var targetFactorial = int.Parse(Console.ReadLine());
            var factorial = CalculateFactorial(targetFactorial);
            var trailingZeroes = TrailingZeroes(factorial);
            Console.WriteLine(trailingZeroes);
        }

        private static BigInteger CalculateFactorial(int target)
        {
            BigInteger factorial = 1;

            for (int current = 1; current <= target; current++)
            {
                factorial *= current;
            }

            return factorial;
        }

        private static int TrailingZeroes(BigInteger number)
        {
            var numberOfZeroes = 0;

            while (true)
            {
                if (number % 10 == 0)
                {
                    numberOfZeroes++;
                    number /= 10;
                }
                else
                {
                    break;
                }
            }

            return numberOfZeroes;
        }
    }
}
