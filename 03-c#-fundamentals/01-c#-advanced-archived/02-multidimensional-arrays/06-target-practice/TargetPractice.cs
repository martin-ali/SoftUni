using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_target_practice
{
    class TargetPractice
    {
        static void Main()
        {
            var matrixDimensions = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();
            var snake = Console.ReadLine();
            var shotParameters = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();
            var impactRow = shotParameters[0];
            var impactCol = shotParameters[1];
            var impactRadius = shotParameters[2];

            var matrix = GenerateMatrix(matrixDimensions[0], matrixDimensions[1], snake);

            Shoot(impactRow, impactCol, impactRadius, matrix);

            ApplyGravity(matrix);

            PrintMatrix(matrix);
        }

        private static void ApplyGravity(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                var characters = new Stack<char>();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col] != ' ')
                    {
                        characters.Push(matrix[row, col]);
                        matrix[row, col] = ' ';
                    }
                }

                for (int row = matrix.GetLength(0) - 1; row >= 0 && characters.Count > 0; row--)
                {
                    matrix[row, col] = characters.Pop();
                }
            }
        }

        private static void Shoot(int impactRow, int impactCol, int impactRadius, char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var cellIsInImpactRadius = Math.Pow(row - impactRow, 2) + Math.Pow(col - impactCol, 2) <= Math.Pow(impactRadius, 2);

                    if (cellIsInImpactRadius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
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

        private static char[,] GenerateMatrix(int rows, int cols, string snake)
        {
            var matrix = new char[rows, cols];
            var currentCharacterIndex = 0;

            // Fill matrix in reverse
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (currentCharacterIndex >= snake.Length)
                    {
                        currentCharacterIndex = 0;
                    }

                    int rowToFill = rows - row - 1;
                    if (row % 2 == 0)
                    {
                        int colToFillInReverse = cols - col - 1;
                        matrix[rowToFill, colToFillInReverse] = snake[currentCharacterIndex++];
                    }
                    else
                    {
                        matrix[rowToFill, col] = snake[currentCharacterIndex++];
                    }

                    // PrintMatrix(matrix);
                    // Console.WriteLine();
                }
            }

            return matrix;
        }
    }
}
/*

5 6
SoftUni
2 3 2

*/
