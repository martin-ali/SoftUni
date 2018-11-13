using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_list_of_predicates
{
    class ListOfPredicatesAlternativeSolution
    {
        static void Main()
        {
            var end = int.Parse(Console.ReadLine());
            List<Predicate<int>> divisorPredicates = GetDivisorPredicates();

            var numbers = new List<int>();
            for (int number = 1; number <= end; number++)
            {
                var divisibleByAll = true;
                foreach (var divisibleByCurrent in divisorPredicates)
                {
                    if (divisibleByCurrent(number) == false)
                    {
                        divisibleByAll = false;
                        break;
                    }
                }

                if (divisibleByAll)
                {
                    numbers.Add(number);
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static List<Predicate<int>> GetDivisorPredicates()
        {
            var divisors = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .Distinct();

            var divisorPredicates = new List<Predicate<int>>();
            foreach (var divisor in divisors)
            {
                divisorPredicates.Add(number => number % divisor == 0);
            }

            return divisorPredicates;
        }
    }
}
