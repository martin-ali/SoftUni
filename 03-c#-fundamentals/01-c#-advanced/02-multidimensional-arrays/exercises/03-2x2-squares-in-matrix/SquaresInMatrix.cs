using System;
using System.IO;
using System.Linq;

namespace _03_2x2_squares_in_matrix
{
    class SquaresInMatrix
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
#endif

            // Get input
            var matrixDimensions = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();

            var matrix = new char[matrixDimensions[0], matrixDimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var characters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < characters.Length; col++)
                {
                    matrix[row, col] = characters[col];
                }
            }

            // Process
            var equalElementsRectanglesCount = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var rectangleIsOfEqualElements = matrix[row, col] == matrix[row + 1, col]
                                                    && matrix[row + 1, col] == matrix[row, col + 1]
                                                    && matrix[row, col + 1] == matrix[row + 1, col + 1];

                    if (rectangleIsOfEqualElements)
                    {
                        equalElementsRectanglesCount++;
                    }
                }
            }

            // Show output
            Console.WriteLine(equalElementsRectanglesCount);
        }
    }
}
/*

3 4
A B B D
E B B B
I J B B

2 2
a b
c d

 */
