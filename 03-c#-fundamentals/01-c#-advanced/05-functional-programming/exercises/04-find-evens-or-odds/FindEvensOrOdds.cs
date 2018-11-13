using System;
using System.Linq;

namespace _04_find_evens_or_odds
{
    class FindEvensOrOdds
    {
        static void Main()
        {
            var range = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
            var parity = Console.ReadLine();

            Predicate<int> isEven = x => Math.Abs(x) % 2 == 0;
            Predicate<int> isOdd = x => Math.Abs(x) % 2 == 1;
            Func<int, bool> filterParity = x => parity == "even"
                                                ? isEven(x)
                                                : isOdd(x);

            var start = range[0];
            var end = range[1];
            var count = end - start + 1;

            var numbers = Enumerable.Range(start, count)
                                    .Where(filterParity);

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
