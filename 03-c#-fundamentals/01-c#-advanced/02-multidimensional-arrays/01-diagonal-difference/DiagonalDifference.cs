using System;
using System.Linq;

namespace _01_diagonal_difference
{
    class DiagonalDifference
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                var numbers = Console.ReadLine().Split().Select(int.Parse);
                var col = 0;
                foreach (var number in numbers)
                {
                    matrix[row, col++] = number;
                }
            }

            var leftDiagonalSum = 0;
            for (int row = 0, col = 0; row < size && col < size; row++, col++)
            {
                leftDiagonalSum += matrix[row, col];
            }

            var rightDiagonalSum = 0;
            for (int row = 0, col = size - 1; row < size && col >= 0; row++, col--)
            {
                rightDiagonalSum += matrix[row, col];
            }

            var difference = Math.Abs(leftDiagonalSum - rightDiagonalSum);
            Console.WriteLine(difference);
        }
    }
}
