using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_list_of_predicates
{
    class ListOfPredicates
    {
        static void Main()
        {
            var end = int.Parse(Console.ReadLine());
            var divisors = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .Distinct();

            var lowestCommonDenominator = LowestCommonDenominator(divisors);

            var numbers = new List<int>();
            for (int number = 1; number <= end; number++)
            {
                if (number % lowestCommonDenominator == 0)
                {
                    numbers.Add(number);
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static int LowestCommonDenominator(IEnumerable<int> numbers)
        {
            var lowestCommonDenominator = numbers.First();
            foreach (var number in numbers)
            {
                lowestCommonDenominator = LowestCommonDenominator(lowestCommonDenominator, number);
            }

            return lowestCommonDenominator;
        }

        private static int LowestCommonDenominator(int first, int second)
        {
            return (first * second) / GreatestCommonDenominator(first, second);
        }

        private static int GreatestCommonDenominator(int first, int second)
        {
            while (first != 0 && second != 0)
            {
                if (first > second)
                {
                    first %= second;
                }
                else
                {
                    second %= first;
                }
            }

            int greatestCommonDenominator = first == 0 ? second : first;
            return greatestCommonDenominator;
        }
    }
}
