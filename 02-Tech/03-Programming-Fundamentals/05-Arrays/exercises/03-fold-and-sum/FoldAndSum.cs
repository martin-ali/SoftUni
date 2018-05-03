using System;
using System.Linq;

namespace _03_fold_and_sum
{
    class FoldAndSum
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var k = elements.Length / 4;

            var leftWing = elements.Take(k).Reverse();
            var rightWing = elements.Skip(k * 3).Reverse();
            var center = elements.Skip(k).Take(k * 2).ToArray();

            var firstRow = leftWing.Concat(rightWing).ToArray();
            var secondRow = center;

            // Simple method
            // var sum = new int[firstRow.Length];
            // for (int current = 0; current < firstRow.Length; current++)
            // {
            //     sum[current] = firstRow[current] + secondRow[current];
            // }

            // LINQ method
            var sum = firstRow.Select((element, index) => element + secondRow[index]);

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
