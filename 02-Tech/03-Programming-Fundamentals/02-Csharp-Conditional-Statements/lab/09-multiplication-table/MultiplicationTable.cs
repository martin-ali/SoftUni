using System;

namespace _09_multiplication_table
{
    class MultiplicationTable
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            for (int current = 1; current <= 10; current++)
            {
                Console.WriteLine($"{number} X {current} = {number * current}");
            }
        }
    }
}
