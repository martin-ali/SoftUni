using System;
using System.Linq;

namespace _01_max_sequence_of_equal_elements
{
    class MaxSequenceOfEqualElements
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var longestSequence = (character: elements[0], length: 1);
            var currentSequence = (character: elements[0], length: 1);

            for (int i = 1; i < elements.Length; i++)
            {
                var current = elements[i];
                var previous = elements[i - 1];
                if (current == previous)
                {
                    currentSequence.length++;
                }
                else
                {
                    currentSequence.length = 1;
                    currentSequence.character = current;
                }

                if (currentSequence.length > longestSequence.length)
                {
                    longestSequence = currentSequence;
                }
            }

            for (int i = 0; i < longestSequence.length; i++)
            {
                Console.Write($"{longestSequence.character} ");
            }

            Console.WriteLine();
        }
    }
}
/*

3 4 4 5 5 5 2 2
7 7 4 4 5 5 3 3
1 2 3 3

 */
