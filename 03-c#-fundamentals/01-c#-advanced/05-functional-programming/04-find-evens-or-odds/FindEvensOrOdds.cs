using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_find_evens_or_odds
{
    class FindEvensOrOdds
    {
        static void Main()
        {
            Func<int, bool> isEven = x => Math.Abs(x) % 2 == 0;
            Func<int, bool> isOdd = x => Math.Abs(x) % 2 == 1;

            var range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var parity = Console.ReadLine();

            var start = range[0];
            var end = range[1];
            var count = end - start + 1;

            var numbersHaveParity = parity == "even" ? isEven : isOdd;
            var numbers = Enumerable
                            .Range(start, count)
                            .Where(numbersHaveParity);

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
