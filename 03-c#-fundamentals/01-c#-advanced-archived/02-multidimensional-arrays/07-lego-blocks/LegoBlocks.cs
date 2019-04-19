using System;
using System.Linq;

namespace _07_lego_blocks
{
    class LegoBlocks
    {
        private static int bothArraysCellCount = 0;

        static void Main()
        {
            // Get input
            var rowCount = int.Parse(Console.ReadLine());
            var firstArray = GetMatrix(rowCount);
            var secondArray = GetMatrix(rowCount);

            // Process
            var targetRowLength = firstArray[0].Length + secondArray[0].Length;
            var arraysFitLikeLegoPieces = true;

            for (int row = 0; row < rowCount; row++)
            {
                if (firstArray[row].Length + secondArray[row].Length != targetRowLength)
                {
                    arraysFitLikeLegoPieces = false;
                    break;
                }
            }

            // Output result
            if (arraysFitLikeLegoPieces)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    string numbers = string.Join(", ", firstArray[row].Concat(secondArray[row].Reverse()));
                    Console.WriteLine($"[{numbers}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {bothArraysCellCount}");
            }
        }

        private static int[][] GetMatrix(int rowCount)
        {
            var array = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                var numbers = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                array[i] = numbers;
                bothArraysCellCount += numbers.Length;
            }

            return array;
        }
    }
}
/*

2
1 1 1 1 1 1
2 1 1 3
1 1
2 2 2 3

*/
