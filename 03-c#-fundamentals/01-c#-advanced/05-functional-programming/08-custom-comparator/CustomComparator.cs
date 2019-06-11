using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_custom_comparator
{
    class EvensBeforeOddsComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            var xIsEven = Math.Abs(x) % 2 == 0;
            var yIsEven = Math.Abs(y) % 2 == 0;

            if (xIsEven && !yIsEven)
            {
                return -1;
            }
            else if (!xIsEven && yIsEven)
            {
                return 1;
            }
            else
            {
                return x.CompareTo(y);
            }
        }
    }

    class CustomComparator
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(numbers, new EvensBeforeOddsComparer());

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
