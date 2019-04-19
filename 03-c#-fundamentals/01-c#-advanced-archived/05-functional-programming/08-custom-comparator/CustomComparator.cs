using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_custom_comparator
{
    public class EvenNumbersFirstComparer : IComparer<int>
    {
        public int Compare(int first, int second)
        {
            var firstIsEven = Math.Abs(first) % 2 == 0;
            var secondIsEven = Math.Abs(second) % 2 == 0;

            if (firstIsEven && secondIsEven == false)
            {
                return -1;
            }
            else if (secondIsEven && firstIsEven == false)
            {
                return 1;
            }
            else
            {
                return first - second;
            }
        }
    }

    public class CustomComparator
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            // var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // var numbers = new List<int>() { -3, 2 };

            numbers.Sort(new EvenNumbersFirstComparer());

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
