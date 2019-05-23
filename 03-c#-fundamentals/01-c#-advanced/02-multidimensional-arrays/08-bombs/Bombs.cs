using System;
using System.Linq;
using System.Collections.Generic;

namespace _08_bombs
{
    class Bombs
    {
        static void Main()
        {
            var boardSize = int.Parse(Console.ReadLine());
            var matrix = CreateMatrix(boardSize);
            var bombs = Console.ReadLine().Split().Select(bomb =>
            {
                var bombCoordinates = bomb.Split(',');
                var row = int.Parse(bombCoordinates[0]);
                var col = int.Parse(bombCoordinates[1]);

                // Can't infer ValueTuple fields until .NET Core 3.0
                return (row: row, col: col);
            });

            foreach (var bomb in bombs)
            {
                if (matrix[bomb.row, bomb.col] <= 0) continue;

                var damage = matrix[bomb.row, bomb.col];
                matrix[bomb.row, bomb.col] = 0;

                // Damage surroundings
                for (int row = bomb.row - 1; row <= bomb.row + 1; row++)
                {
                    for (int col = bomb.col - 1; col <= bomb.col + 1; col++)
                    {
                        if (IsInRange(matrix, row, col))
                        {
                            if (matrix[row, col] > 0) matrix[row, col] -= damage;
                        }
                    }
                }
            }

            Console.WriteLine($"Alive cells: {GetSurvivingCellCount(matrix)}");
            Console.WriteLine($"Sum: {GetSurvivingCellsSum(matrix)}");
            PrintMatrix(matrix);
        }

        private static int GetSurvivingCellCount(int[,] matrix)
        {
            var count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0) count++;
                }
            }

            return count;
        }

        private static int GetSurvivingCellsSum(int[,] matrix)
        {
            var sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0) sum += matrix[row, col];
                }
            }

            return sum;
        }

        private static int[,] CreateMatrix(int size)
        {
            var matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                var items = Console.ReadLine().Split().Select(int.Parse);
                var col = 0;
                foreach (var item in items)
                {
                    matrix[row, col++] = item;
                }
            }

            return matrix;
        }

        private static bool IsInRange<G>(G[,] matrix, int row, int col)
        {
            return 0 <= row && row < matrix.GetLength(0)
                && 0 <= col && col < matrix.GetLength(1);
        }

        private static void PrintMatrix<G>(G[,] matrix)
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