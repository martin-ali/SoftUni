using System;
using System.Linq;

namespace _01_array_statistics
{
    class ArrayStatistics
    {
        static void Main(string[] args)
        {
            var arr = Console
                        .ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();

            var min = arr.Min();
            var max = arr.Max();
            var sum = arr.Sum();
            var average = arr.Average();

            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = {average}");
        }
    }
}
