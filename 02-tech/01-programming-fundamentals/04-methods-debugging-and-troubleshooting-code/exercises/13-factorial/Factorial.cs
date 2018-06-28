using System;
using System.Numerics;

namespace _13_factorial
{
    class Factorial
    {
        static void Main()
        {
            var targetFactorial = int.Parse(Console.ReadLine());
            BigInteger factorial = CalculateFactorial(targetFactorial);
            Console.WriteLine(factorial);
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
    }
}
