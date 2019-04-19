using System;
using System.Linq;

namespace _01_matrix_of_palindromes
{
    class MatrixOfPalindromes
    {
        static void Main()
        {
            var rowsAndColsCount = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();

            var rowCount = rowsAndColsCount[0];
            var colCount = rowsAndColsCount[1];

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    var edgeCharacter = (char)(97 + row);
                    var middleCharacter = (char)(97 + row + col);
                    Console.Write($"{edgeCharacter}{middleCharacter}{edgeCharacter} ");
                }

                Console.WriteLine();
            }
        }
    }
}
