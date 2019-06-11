using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_list_of_predicates
{
    class ListOfPredicates
    {
        static void Main()
        {
            var ceiling = int.Parse(Console.ReadLine());
            var divisors = Console.ReadLine().Split().Select(int.Parse).Distinct();
            var divisorTests = GetDivisionTests(divisors);

            var divisibleNumbers = new List<int>();
            for (int dividend = 1; dividend <= ceiling; dividend++)
            {
                if (IsDivisibleByALl(dividend, divisorTests))
                {
                    divisibleNumbers.Add(dividend);
                }
            }

            Console.WriteLine(string.Join(' ', divisibleNumbers));
        }

        private static bool IsDivisibleByALl(int dividend, List<Func<int, bool>> divisorTests)
        {
            foreach (var isDivisible in divisorTests)
            {
                if (isDivisible(dividend) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static List<Func<int, bool>> GetDivisionTests(IEnumerable<int> divisors)
        {
            var divisionTests = new List<Func<int, bool>>();
            foreach (var divisor in divisors)
            {
                divisionTests.Add(dividend => dividend % divisor == 0);
            }

            return divisionTests;
        }
    }
}
