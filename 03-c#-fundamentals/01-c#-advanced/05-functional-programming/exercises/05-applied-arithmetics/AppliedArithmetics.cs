using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_applied_arithmetics
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<int> Map(this IEnumerable<int> items, Func<int, int> mutator)
        {
            var mutatedItems = new int[items.Count()];
            var index = 0;
            foreach (var item in items)
            {
                mutatedItems[index++] = mutator(item);
            }

            return mutatedItems;
        }
    }

    class AppliedArithmetics
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse);

            var command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = numbers.Map(x => x + 1);
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Map(x => x - 1);
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Map(x => x * 2);
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(' ', numbers));
                }

                command = Console.ReadLine();
            }
        }
    }
}
