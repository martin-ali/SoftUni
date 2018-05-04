using System;
using System.Linq;

namespace _10_pairs_by_difference
{
    class PairsByDifference
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var difference = int.Parse(Console.ReadLine());

            var numberOfPairs = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int current = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    var currentPairEqualsSum = (current - numbers[j] == difference) || (current - numbers[j] == -difference);
                    if (currentPairEqualsSum)
                    {
                        numberOfPairs++;
                    }
                }
            }

            Console.WriteLine(numberOfPairs);
        }
    }
}
/*

1 5 3 4 2
2

5 3 8 10 12 1
1

 */
