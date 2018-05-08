using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_longest_increasing_subsequence
{
    class LongestIncreasingSubsequence
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var sequences = new List<List<int>>();

            for (int i = 0; i < numbers.Count; i++)
            {
                sequences.Add(new List<int>() { numbers[i] });
            }

            var longestSequence = sequences[0];
            for (int current = 0; current < numbers.Count; current++)
            {
                for (int comparison = 0; comparison < current; comparison++)
                {
                    if (numbers[comparison] < numbers[current])
                    {
                        // Get LIS
                        if (sequences[comparison].Count >= sequences[current].Count)
                        {
                            // Shallow copy
                            sequences[current] = sequences[comparison].ToList();
                            sequences[current].Add(numbers[current]);
                        }

                        // In case of multiple sequences of same length, save a copy of the leftmost
                        if (sequences[current].Count > longestSequence.Count)
                        {
                            longestSequence = sequences[current].ToList();
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", longestSequence));
        }
    }
}
/*

1
7 3 5 8 -1 0 6 7
1 2 5 3 5 2 4 1
0 10 20 30 30 40 1 50 2 3 4 5 6
11 12 13 3 14 4 15 5 6 7 8 7 16 9 8
3 14 5 12 15 7 8 9 11 10 1

 */
