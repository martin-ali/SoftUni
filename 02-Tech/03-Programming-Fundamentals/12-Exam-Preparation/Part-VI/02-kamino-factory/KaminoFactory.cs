using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_kamino_factory
{
    class KaminoFactory
    {
        static void Main()
        {
            var length = int.Parse(Console.ReadLine());
            var dnaSequences = new List<(int length, int start, int sum, int sample, string sequence)>();

            var input = Console.ReadLine();
            for (int sample = 1; input != "Clone them!"; sample++, input = Console.ReadLine())
            {
                var dna = input.Replace("!", "");
                var subSeq = LongestSubsequenceLength(dna);

                dnaSequences.Add((subSeq.length, subSeq.start, subSeq.sum, sample, dna));
            }

            var bestDna = dnaSequences.OrderBy(s => s.length).ThenBy(s => s.start).ThenByDescending(s => s.sum).First();
            Console.WriteLine($"Best DNA sample {bestDna.sample} with sum: {bestDna.sum}.");
            Console.WriteLine(string.Join(" ", bestDna.sequence.ToCharArray()));
            Console.WriteLine(1);
        }

        private static (int length, int start, int sum) LongestSubsequenceLength(string dna)
        {
            var longestSequenceLength = 0;
            var currentSequenceLength = 0;
            var start = 0;
            var sum = 0;

            for (int i = 0; i < dna.Length; i++)
            {
                if (dna[i] == '1')
                {
                    currentSequenceLength++;
                    sum++;
                }
                else
                {
                    currentSequenceLength = 0;
                }

                if (currentSequenceLength > longestSequenceLength)
                {
                    longestSequenceLength = currentSequenceLength;
                    start = i - currentSequenceLength + 1;
                }
            }

            return (longestSequenceLength, start, sum);
        }
    }
}
/*

5
1!0!1!1!0
0!1!1!0!0
Clone them!

4
1!1!0!1
1!0!0!1
1!1!0!0
Clone them!

 */
