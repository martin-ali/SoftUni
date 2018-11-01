using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_sets_of_elements
{
    class SetsOfElements
    {
        static void Main()
        {
            var setLengths = Console
                            .ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .ToArray();

            // Populate first set
            var firstSetLength = setLengths[0];
            var firstSet = new List<int>();
            for (int i = 0; i < firstSetLength; i++)
            {
                var number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            // Populate second set; Populate numbersInBothSets set
            var secondSetLength = setLengths[1];
            var secondSet = new List<int>();
            for (int i = 0; i < secondSetLength; i++)
            {
                var number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            // Print result
            Console.WriteLine(string.Join(' ', firstSet.Intersect(secondSet)));
        }
    }
}
