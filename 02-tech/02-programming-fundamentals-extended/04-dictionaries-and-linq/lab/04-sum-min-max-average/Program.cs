using System;
using System.Linq;

namespace _04_sum_min_max_average
{
    class Program
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            var numbers = new int[numberOfLines];

            for (int index = 0; index < numberOfLines; index++)
            {
                numbers[index] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Sum = {numbers.Sum()}");
            Console.WriteLine($"Min = {numbers.Min()}");
            Console.WriteLine($"Max = {numbers.Max()}");
            Console.WriteLine($"Average = {numbers.Average()}");
        }
    }
}
