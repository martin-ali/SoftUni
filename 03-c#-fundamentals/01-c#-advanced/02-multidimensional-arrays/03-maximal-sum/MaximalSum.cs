using System;
using System.Linq;

namespace _03_maximal_sum
{
    class MaximalSum
    {
        static void Main()
        {
            var matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = matrixDimensions[0];
            var cols = matrixDimensions[1];
            var matrix = PopulateMatrix(rows, cols);

            var maxSum = 0;
            var maxSumCells = new int[3, 3];
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    var result = GetSumAndCellsOf3x3Square(matrix, row, col);
                    if (result.sum > maxSum)
                    {
                        maxSum = result.sum;
                        maxSumCells = result.cells;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            PrintMatrix(maxSumCells);
        }

        private static int[,] PopulateMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
                var col = 0;
                foreach (var number in numbers)
                {
                    matrix[row, col++] = number;
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static (int sum, int[,] cells) GetSumAndCellsOf3x3Square(int[,] matrix, int startRow, int startCol)
        {
            var cells = new int[3, 3];
            var sum = 0;
            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    sum += matrix[row, col];
                    cells[row - startRow, col - startCol] = matrix[row, col];
                }
            }

            return (sum, cells);
        }
    }
}
