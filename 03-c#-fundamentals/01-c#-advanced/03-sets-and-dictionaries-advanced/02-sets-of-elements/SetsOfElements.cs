using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_sets_of_elements
{
    class SetsOfElements
    {
        static void Main()
        {
            var parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstSetLength = parameters[0];
            var secondSetLength = parameters[1];

            var firstSet = new HashSet<int>();
            for (int i = 0; i < firstSetLength; i++)
            {
                var number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            var secondSet = new HashSet<int>();
            for (int i = 0; i < secondSetLength; i++)
            {
                var number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            var numbersPresentInBothSets = firstSet.Intersect(secondSet);
            Console.WriteLine(string.Join(' ', numbersPresentInBothSets));
        }
    }
}
