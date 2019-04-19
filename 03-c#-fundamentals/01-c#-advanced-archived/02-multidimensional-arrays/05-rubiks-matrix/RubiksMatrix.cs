using System;
using System.Linq;

namespace _05_rubiks_matrix
{
    class RubiksMatrix
    {
        static void Main()
        {
            // Get input
            var matrix = GenerateMatrix();

            // Process
            ProcessCommands(matrix);
        }

        private static int[][] GenerateMatrix()
        {
            var matrixDimensions = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();

            var matrix = new int[matrixDimensions[0]][];

            var currentNumber = 1;
            for (int row = 0; row < matrix.GetLength(0); row++, currentNumber += matrixDimensions[1])
            {
                matrix[row] = Enumerable.Range(currentNumber, matrixDimensions[1]).ToArray();
            }

            return matrix;
        }

        private static void ProcessCommands(int[][] matrix)
        {
            var commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                var commandData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var dimension = int.Parse(commandData[0]);
                var direction = commandData[1];
                var moves = int.Parse(commandData[2]);

                if (direction == "up")
                {
                    ShiftColumnUp(matrix, dimension, moves);
                }
                else if (direction == "down")
                {
                    ShiftColumnUp(matrix, dimension, -moves);
                }
                else if (direction == "left")
                {
                    matrix[dimension] = ShiftRowLeft(matrix[dimension], moves);
                }
                else if (direction == "right")
                {
                    matrix[dimension] = ShiftRowLeft(matrix[dimension], -moves);
                }
            }

            Rearrange(matrix);
        }

        private static void Rearrange(int[][] matrix)
        {
            int currentNumber = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == currentNumber)
                    {
                        Console.WriteLine("No swap required");
                        currentNumber++;
                    }
                    else
                    {
                        SwapWithNextIncrement(matrix, currentNumber, row, col);
                        currentNumber++;
                    }
                }
            }
        }

        private static void SwapWithNextIncrement(int[][] matrix, int currentNumber, int startRow, int startCol)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[startRow].Length; col++)
                {
                    if (matrix[row][col] == currentNumber)
                    {
                        Console.WriteLine($"Swap ({startRow}, {startCol}) with ({row}, {col})");

                        // Swap
                        matrix[row][col] = matrix[startRow][startCol];
                        matrix[startRow][startCol] = currentNumber;

                        return;
                    }
                }
            }
        }

        private static void ShiftColumnUp(int[][] matrix, int column, int moves)
        {
            moves %= matrix.Length;
            var oldValues = new int[matrix.Length];

            for (int row = 0; row < matrix.Length; row++)
            {
                oldValues[row] = matrix[row][column];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                var indexToShift = row + moves;

                if (indexToShift < 0)
                {
                    indexToShift += matrix.Length;
                }
                else if (indexToShift >= matrix.Length)
                {
                    indexToShift -= matrix.Length;
                }

                matrix[row][column] = oldValues[indexToShift];
            }
        }

        private static int[] ShiftRowLeft(int[] arr, int moves)
        {
            // Doable with .Take()  and .Skip()
            moves %= arr.Length;
            var shiftedNumbers = new int[arr.Length];

            for (int index = 0; index < shiftedNumbers.Length; index++)
            {
                var indexToShift = index + moves;

                if (indexToShift < 0)
                {
                    indexToShift += shiftedNumbers.Length;
                }
                else if (indexToShift >= shiftedNumbers.Length)
                {
                    indexToShift -= shiftedNumbers.Length;
                }

                shiftedNumbers[index] = arr[indexToShift];
            }

            return shiftedNumbers;
        }
    }
}
/*

3 3
2
1 down 1
1 left 1

3 3
2
0 down 3
0 left 3

*/
