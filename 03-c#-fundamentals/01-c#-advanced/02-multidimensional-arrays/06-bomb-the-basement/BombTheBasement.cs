using System;
using System.Linq;

namespace _06_bomb_the_basement
{
    class BombTheBasement
    {
        static void Main()
        {
            var matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = matrixDimensions[0];
            var cols = matrixDimensions[1];
            var basement = new int[rows, cols];

            var bombParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bomb = (row: bombParameters[0], col: bombParameters[1], radius: bombParameters[2]);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (CellIsInImpactRadius(row, col, bomb))
                    {
                        basement[row, col] = 1;
                    }
                }
            }

            ApplyAntiGravity(basement);
            PrintMatrix(basement);
        }

        private static void ApplyAntiGravity(int[,] basement)
        {
            // Go column by column
            for (int col = 0; col < basement.GetLength(1); col++)
            {
                // Count items
                var itemCount = 0;
                for (int row = 0; row < basement.GetLength(0); row++)
                {
                    if (basement[row, col] == 1)
                    {
                        itemCount++;
                        basement[row, col] = 0;
                    }
                }

                // Place items
                for (int row = 0; row < basement.GetLength(0) && itemCount > 0; row++)
                {
                    basement[row, col] = 1;
                    itemCount--;
                }
            }
        }

        private static bool CellIsInImpactRadius(int row, int col, (int row, int col, int radius) bomb)
        {
            int a = (row - bomb.row) * (row - bomb.row);
            int b = (col - bomb.col) * (col - bomb.col);
            var distance = Math.Sqrt(a + b);

            return distance <= bomb.radius;
        }

        private static void PrintMatrix(int[,] matrix)
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
