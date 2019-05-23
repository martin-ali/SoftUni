using System;
using System.Linq;

namespace _04_matrix_shuffling
{
    class MatrixShuffling
    {
        private const string INVALID_INPUT = "Invalid input!";

        static void Main()
        {
            var matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = matrixDimensions[0];
            var cols = matrixDimensions[1];
            var matrix = PopulateMatrix(rows, cols);

            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "END")
                {
                    break;
                }
                else if (input.Length != 5 || input[0] != "swap")
                {
                    Console.WriteLine(INVALID_INPUT);
                    continue;
                }

                var row1 = int.Parse(input[1]);
                var col1 = int.Parse(input[2]);
                var row2 = int.Parse(input[3]);
                var col2 = int.Parse(input[4]);

                bool allParametersAreValid = 0 <= row1 && row1 < matrix.GetLength(0)
                                        && 0 <= row2 && row2 < matrix.GetLength(0)
                                        && 0 <= col1 && col1 < matrix.GetLength(1)
                                        && 0 <= col2 && col2 < matrix.GetLength(1);
                if (allParametersAreValid == false)
                {
                    Console.WriteLine(INVALID_INPUT);
                    continue;
                }

                var row1Col1Value = matrix[row1, col1];
                var row2Col2Value = matrix[row2, col2];

                matrix[row1, col1] = row2Col2Value;
                matrix[row2, col2] = row1Col1Value;

                PrintMatrix(matrix);
            }
        }

        private static string[,] PopulateMatrix(int rows, int cols)
        {
            var matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var items = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var col = 0;
                foreach (var item in items)
                {
                    matrix[row, col++] = item;
                }
            }

            return matrix;
        }

        private static void PrintMatrix(string[,] matrix)
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
    }
}
