using System;
using System.Linq;

namespace _05_largest_three_numbers
{
    class Program
    {
        static void Main()
        {
            var largestThreeNumbers = Console
                                        .ReadLine()
                                        .Split(' ')
                                        .Select(int.Parse)
                                        .OrderByDescending(x => x)
                                        .Take(3);

            Console.WriteLine(String.Join(" ", largestThreeNumbers));
        }
    }
}
