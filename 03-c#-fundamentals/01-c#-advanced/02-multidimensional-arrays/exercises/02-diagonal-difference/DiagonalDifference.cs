using System;
using System.Linq;

namespace _02_diagonal_difference
{
    class DiagonalDifference
    {
        static void Main()
        {
            var matrixRowCount = int.Parse(Console.ReadLine());
            var matrix = new int[matrixRowCount][];

            for (int row = 0; row < matrixRowCount; row++)
            {
                matrix[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var primaryDiagonalSum = 0;
            for (int row = 0, col = 0; row < matrixRowCount && col < matrix[row].Length; row++, col++)
            {
                primaryDiagonalSum += matrix[row][col];
            }

            var secondaryDiagonalSum = 0;
            for (int row = 0, col = matrix[row].Length - 1; row < matrixRowCount && col >= 0; row++, col--)
            {
                secondaryDiagonalSum += matrix[row][col];
            }

            var difference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(difference);
        }
    }
}
