using System;

namespace _11_five_different_numbers
{
    class FiveDifferentNumbers
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            for (int row = a; row <= a * 2; row++)
            {
                var numbers = 
                for (int col = 0; col < 5; col++)
                {
                    Console.Write($"{row + col} ");
                }

                Console.WriteLine();
            }
        }
    }
}
