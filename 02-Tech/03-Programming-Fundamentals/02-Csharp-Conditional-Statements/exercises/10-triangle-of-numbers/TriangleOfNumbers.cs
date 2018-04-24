using System;

namespace _10_triangle_of_numbers
{
    class TriangleOfNumbers
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            for (int row = 1; row <= size; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    Console.Write($"{row} ");
                }

                Console.WriteLine();
            }
        }
    }
}
