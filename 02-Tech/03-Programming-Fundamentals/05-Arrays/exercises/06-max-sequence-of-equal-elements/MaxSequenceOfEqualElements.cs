using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_max_sequence_of_equal_elements
{
    class MaxSequenceOfEqualElements
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

                if (current == previous)
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
