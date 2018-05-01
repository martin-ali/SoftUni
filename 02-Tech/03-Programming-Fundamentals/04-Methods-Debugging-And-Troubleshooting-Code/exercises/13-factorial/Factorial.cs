using System;
using System.Numerics;

namespace _13_factorial
{
    class Factorial
    {
        static void Main()
        {
            var targetFactorial = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;

            for (int current = 1; current <= targetFactorial; current++)
            {
                factorial *= current;
            }

            Console.WriteLine(factorial);
        }
    }
}
