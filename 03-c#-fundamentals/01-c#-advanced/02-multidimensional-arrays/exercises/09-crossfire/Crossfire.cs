using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _09_crossfire
{
    class Crossfire
    {
        private const int destroyed = -1;

        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test2.txt"));
#endif

            var matrixDimensions = Console.ReadLine()
                                    .Split(' ')
                                    .Select(int.Parse)
                                    .ToArray();

            var rows = matrixDimensions[0];
            var cols = matrixDimensions[1];
            var matrix = GenerateMatrix(rows, cols);

            var command = Console.ReadLine();
            while (command != "Nuke it from orbit")
            {
                var parameters = command
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

                var impactRow = parameters[0];
                var impactCol = parameters[1];
                var impactRadius = parameters[2];

                CreateImpact(matrix, impactRow, impactCol, impactRadius);

                command = Console.ReadLine();
            }

            PrintMatrix(matrix);
        }

        private static void CreateImpact(List<List<int>> matrix, int targetRow, int targetCol, int impactRadius)
        {
            for (int row = targetRow - impactRadius; row <= targetRow + impactRadius; row++)
            {
                if (IsInsideMatrix(matrix, row, targetCol))
                {
                    matrix[row][targetCol] = destroyed;
                }
            }

            for (int col = targetCol - impactRadius; col <= targetCol + impactRadius; col++)
            {
                if (IsInsideMatrix(matrix, targetRow, col))
                {
                    matrix[targetRow][col] = destroyed;
                }
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                matrix[row].RemoveAll(x => x == destroyed);
            }

            matrix.RemoveAll(row => row.Count == 0);
        }

        private static bool IsInsideMatrix(List<List<int>> matrix, int row, int col)
        {
            return (0 <= row && row < matrix.Count) && (0 <= col && col < matrix[row].Count);
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                Console.WriteLine(string.Join(' ', matrix[row]));
            }
        }

        private static List<List<int>> GenerateMatrix(int rows, int cols)
        {
            var matrix = new List<List<int>>();

            var currentNumber = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>());
                for (int i = 0; i < cols; i++)
                {
                    matrix[row].Add(currentNumber++);
                }
            }

            return matrix;
        }
    }
}