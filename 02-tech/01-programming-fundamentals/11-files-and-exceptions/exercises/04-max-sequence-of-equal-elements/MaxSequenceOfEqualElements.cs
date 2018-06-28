using System;
using System.Collections.Generic;
using System.IO;

namespace _04_max_sequence_of_equal_elements
{
    class MaxSequenceOfEqualElements
    {
        static void Main()
        {
            var lines = File.ReadAllLines("input.txt");

            foreach (var line in lines)
            {
                var elements = line.Split();
                var longestSequence = new List<string>() { elements[0] };
                var currentSequence = new List<string>() { elements[0] };

                for (int i = 1; i < elements.Length; i++)
                {
                    if (elements[i] != elements[i - 1])
                    {
                        currentSequence.Clear();
                    }

                    currentSequence.Add(elements[i]);

                    if (currentSequence.Count > longestSequence.Count)
                    {
                        longestSequence.Clear();
                        longestSequence.AddRange(currentSequence);
                    }
                }

                File.AppendAllText("output.txt", string.Join(" ", longestSequence) + Environment.NewLine);
            }
        }
    }
}
