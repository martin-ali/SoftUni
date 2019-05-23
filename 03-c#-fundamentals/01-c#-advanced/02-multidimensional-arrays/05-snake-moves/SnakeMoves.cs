using System;
using System.Linq;

namespace _05_snake_moves
{
    class SnakeMoves
    {
        static void Main()
        {
            var matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var snake = Console.ReadLine();
            var rows = matrixDimensions[0];
            var cols = matrixDimensions[1];
            var matrix = new char[rows, cols];

            var characterIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (characterIndex >= snake.Length)
                    {
                        characterIndex = 0;
                    }

                    matrix[row, col] = snake[characterIndex++];
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
