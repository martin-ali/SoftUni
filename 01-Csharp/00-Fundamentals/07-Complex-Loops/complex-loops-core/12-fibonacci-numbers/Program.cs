using System;

namespace _12_fibonacci_numbers
{
    class Program
    {
        static void Main()
        {
            var fibonacciNumberToGet = int.Parse(Console.ReadLine());

            var previous = 0;
            var current = 1;

            for (int i = 0; i < fibonacciNumberToGet; i++)
            {
                var fibonacci = previous + current;
                previous = current;                
                current = fibonacci;
            }

            Console.WriteLine(current);
        }
    }
}
