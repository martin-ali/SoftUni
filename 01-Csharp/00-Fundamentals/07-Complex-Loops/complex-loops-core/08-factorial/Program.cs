using System;

namespace _08_factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var factorial = 1;
            for (int current = 1; current <= number; current++)
            {
                factorial *= current;
            }

            Console.WriteLine(factorial);
        }
    }
}
