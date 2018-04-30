using System;

namespace _05_fibonacci_numbers
{
    class FibonacciNumbers
    {
        static void Main()
        {
            var fibonacciTarget = int.Parse(Console.ReadLine());
            int fibonacci = GetFibonacci(fibonacciTarget);

            Console.WriteLine(fibonacci);
        }

        private static int GetFibonacci(int fibonacciTarget)
        {
            var firstFibonacci = 1;
            var secondFibonacci = 1;
            var fibonacci = 1;

            for (int current = 1; current < fibonacciTarget; current++)
            {
                fibonacci = firstFibonacci + secondFibonacci;

                secondFibonacci = firstFibonacci;
                firstFibonacci = fibonacci;
            }

            return fibonacci;
        }
    }
}
