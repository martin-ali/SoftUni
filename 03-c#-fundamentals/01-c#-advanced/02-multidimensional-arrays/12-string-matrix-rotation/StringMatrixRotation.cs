using System;
using System.Collections.Generic;
using System.IO;

namespace _12_string_matrix_rotation
{
    class StringMatrixRotation
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test3.txt"));
#endif

            var matrix = new List<string>();
            var angleString = Console.ReadLine().Replace("Rotate(", "").Replace(")", "");
            var angle = int.Parse(angleString) % 360;

            var input = Console.ReadLine();
            var longestRowLength = 0;
            while (input != "END")
            {
                matrix.Add(input);

                longestRowLength = Math.Max(longestRowLength, input.Length);

                input = Console.ReadLine();
            }

            DrawMatrixAtAngle(matrix, angle, longestRowLength);
        }

        private static bool CoordinatesAreInMatrix(List<string> matrix, int row, int col)
        {
            return (0 <= row && row < matrix.Count)
                && (0 <= col && col < matrix[row].Length);
        }

        private static void DrawMatrixAtAngle(List<string> matrix, int rotationAngle, int longestRowLength)
        {
            if (rotationAngle == 90)
            {
                PrintMatrixAt90Degrees(matrix, longestRowLength);
            }
            else if (rotationAngle == 180)
            {
                PrintMatrixAt180Degrees(matrix, longestRowLength);
            }
            else if (rotationAngle == 270)
            {
                PrintMatrixAt270Degrees(matrix, longestRowLength);
            }
            else
            {
                PrintMatrixNormally(matrix, longestRowLength);
            }
        }

        private static void PrintMatrixAt90Degrees(List<string> matrix, int longestRowLength)
        {
            for (int col = 0; col < longestRowLength; col++)
            {
                for (int row = matrix.Count - 1; row >= 0; row--)
                {
                    if (CoordinatesAreInMatrix(matrix, row, col))
                    {
                        Console.Write(matrix[row][col]);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }
        }

        private static void PrintMatrixAt180Degrees(List<string> matrix, int longestRowLength)
        {
            for (int row = matrix.Count - 1; row >= 0; row--)
            {
                for (int col = longestRowLength - 1; col >= 0; col--)
                {
                    if (CoordinatesAreInMatrix(matrix, row, col))
                    {
                        Console.Write(matrix[row][col]);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }
        }

        private static void PrintMatrixAt270Degrees(List<string> matrix, int longestRowLength)
        {
            for (int col = longestRowLength - 1; col >= 0; col--)
            {
                for (int row = 0; row < matrix.Count; row++)
                {
                    if (CoordinatesAreInMatrix(matrix, row, col))
                    {
                        Console.Write(matrix[row][col]);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }
        }

        private static void PrintMatrixNormally(List<string> matrix, int longestRowLength)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < longestRowLength; col++)
                {
                    if (CoordinatesAreInMatrix(matrix, row, col))
                    {
                        Console.Write(matrix[row][col]);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
