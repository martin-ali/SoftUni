using System;
using System.Linq;

namespace _02_2x2_squares_in_matrix
{
    class SquaresInMatrix
    {
        static void Main()
        {
            var matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = matrixDimensions[0];
            var cols = matrixDimensions[1];
            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var characters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse);
                var col = 0;
                foreach (var character in characters)
                {
                    matrix[row, col++] = character;
                }
            }

            var squaresOfEqualCharsCount = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row + 1, col]
                    && matrix[row + 1, col] == matrix[row, col + 1]
                    && matrix[row, col + 1] == matrix[row + 1, col + 1])
                    {
                        squaresOfEqualCharsCount++;
                    }
                }
            }

            Console.WriteLine(squaresOfEqualCharsCount);
        }
    }
}
