using System;
using System.Linq;

namespace _04_maximal_sum
{
    class MaximalSum
    {
        static void Main()
        {
            // Get input
            var matrixDimensions = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();

            var matrix = new int[matrixDimensions[0], matrixDimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var characters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < characters.Length; col++)
                {
                    matrix[row, col] = characters[col];
                }
            }

            // Process
            var maxSum = 0;
            var maxRectangle = new int[3, 3];

            for (int matrixRow = 0; matrixRow < matrix.GetLength(0) - 2; matrixRow++)
            {
                for (int matrixCol = 0; matrixCol < matrix.GetLength(1) - 2; matrixCol++)
                {
                    var sum = SumRectangle(matrix, matrixRow, matrixCol);

                    if (sum.value > maxSum)
                    {
                        maxSum = sum.value;
                        maxRectangle = sum.rectangle;
                    }
                }
            }

            // Print output
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < maxRectangle.GetLength(0); row++)
            {
                for (int col = 0; col < maxRectangle.GetLength(1); col++)
                {
                    Console.Write($"{maxRectangle[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static (int value, int[,] rectangle) SumRectangle(int[,] matrix, int matrixRow, int matrixCol)
        {
            var rectangle = new int[3, 3];
            var sum = 0;

            // Sum 3x3 rectangle
            for (int rectangleRow = 0; rectangleRow < 3; rectangleRow++)
            {
                for (int rectangleCol = 0; rectangleCol < 3; rectangleCol++)
                {
                    int currentNumber = matrix[rectangleRow + matrixRow, rectangleCol + matrixCol];
                    sum += currentNumber;
                    rectangle[rectangleRow, rectangleCol] = currentNumber;
                }
            }

            return (value: sum, rectangle);
        }
    }
}
