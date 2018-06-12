using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_anonymous_threat
{
    class AnonymousThreat
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split().ToList();

            var input = Console.ReadLine().Split();
            while (input[0] != "3:1")
            {
                var start = int.Parse(input[1]);
                var end = int.Parse(input[2]);

                if (input[0] == "merge")
                {
                    elements = Merge(elements, start, end);
                }
                else
                {
                    elements = Divide(elements, start, end);
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", elements));
        }

        private static List<string> Merge(List<string> elements, int startIndex, int endIndex)
        {
            startIndex = Clamp(0, startIndex, elements.Count - 1);
            endIndex = Clamp(0, endIndex, elements.Count - 1);

            var mergedElements = string.Empty;
            for (int i = startIndex; i <= endIndex; i++)
            {
                mergedElements += elements[i];
            }

            elements.RemoveRange(startIndex, endIndex - startIndex + 1);
            elements.Insert(startIndex, mergedElements);

            return elements;
        }

        private static List<string> Divide(List<string> elements, int index, int partitionCount)
        {
            var partition = elements[index];
            index = Clamp(0, index, elements.Count - 1);
            partitionCount = Clamp(0, partitionCount, partition.Length);
            var partitionLength = partition.Length / partitionCount;

            var dividedPartitions = new List<string>();
            var current = 0;
            for (current = 0; current < partitionCount - 1; current++)
            {
                dividedPartitions.Add(partition.Substring(current * partitionLength, partitionLength));
            }

            dividedPartitions.Add(partition.Substring(current * partitionLength));
            elements.RemoveAt(index);
            elements.InsertRange(index, dividedPartitions);

            return elements;
        }

        private static int Clamp(int min, int value, int max)
        {
            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
        }
    }
}
