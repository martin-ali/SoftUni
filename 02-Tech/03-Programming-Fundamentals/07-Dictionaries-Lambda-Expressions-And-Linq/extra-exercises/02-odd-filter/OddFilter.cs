using System;
using System.Linq;

namespace _02_odd_filter
{
    class OddFilter
    {
        static void Main()
        {
            var input = Console
                        .ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .Where(num => num % 2 == 0);
            var average = input.Average();
            var oddifiedNumbers = input.Select(num => num > average ? num + 1 : num - 1);
            Console.WriteLine(string.Join(" ", oddifiedNumbers));
        }
    }
}
/*

1 2 3 4 5 6 7 8 9 10
99 88 77 66 55 4 33 22 11
23 32 199 723 8127 95

 */
