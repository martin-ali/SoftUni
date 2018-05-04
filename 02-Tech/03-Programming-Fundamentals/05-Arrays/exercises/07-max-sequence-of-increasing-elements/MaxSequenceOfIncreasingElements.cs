using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_max_sequence_of_increasing_elements
{
    class MaxSequenceOfIncreasingElements
    {
        static void Main()
        {
            var elements = Console
                            .ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .ToArray();

            var longestSequence = new List<int>();
            var currentSequence = new List<int>() { elements[0] };
            for (int i = 1; i < elements.Length; i++)
            {
                var current = elements[i];
                var previous = elements[i - 1];

                if (current > previous)
                {
                    currentSequence.Add(current);
                }
                else
                {
                    currentSequence = new List<int>();
                    currentSequence.Add(current);
                }

                if (currentSequence.Count > longestSequence.Count)
                {
                    longestSequence = currentSequence;
                }
            }

            Console.WriteLine(string.Join(" ", longestSequence));
        }
    }
}
/*

2 1 1 2 3 3 2 2 2 1
1 1 1 2 3 1 3 3
4 4 4 4
0 1 1 5 2 2 6 3 3

 */
