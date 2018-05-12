using System;
using System.Linq;

namespace _01_sort_times
{
    class SortTimes
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').OrderBy(time => time);
            Console.WriteLine(string.Join(", ", input));
        }
    }
}

/*

00:00 06:04 02:59 10:33 11:22 06:01
04:25 04:21 04:19
00:00 23:59 12:00 16:00

 */
