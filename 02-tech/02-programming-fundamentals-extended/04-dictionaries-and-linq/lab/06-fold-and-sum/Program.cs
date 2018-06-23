using System;
using System.Linq;

namespace _06_fold_and_sum
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var k = numbers.Count / 4;

            var firstRowLeft = numbers.Take(k).Reverse();
            var firstRowRight = numbers.Skip(k * 3).Take(k).Reverse();

            var firstRow = firstRowLeft.Concat(firstRowRight);
            var secondRow = numbers.Skip(k).Take(k * 2).ToArray();

            var sum = firstRow.Select((x, index) => x + secondRow[index]);

            Console.WriteLine(String.Join(" ", sum));
        }
    }
}
