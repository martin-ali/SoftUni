using System;

namespace draw_butterfly
{
    class Program
    {
        // Could be written elegantly with a single loop, this method chosen for simplicity
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int height = 2 * (size - 2) + 1;
            int width = (2 * size) - 1;

            // Draw top
            int topHeight = size - 2;
            string wingStar = new String('*', size - 2);
            string wingDash = new String('-', size - 2);
            for (int row = 2; row < size; row++)
            {
                if (row % 2 == 0)
                {
                    Console.WriteLine($"{wingStar}\\ /{wingStar}");
                }
                else
                {
                    Console.WriteLine($"{wingDash}\\ /{wingDash}");
                }
            }

            // Draw mid
            int midHeight = 1;
            Console.WriteLine($"{new String(' ', size - 1)}@");

            // Draw bottom
            int bottomHeight = size - 2;
            for (int row = 2; row < size; row++)
            {
                if (row % 2 == 0)
                {
                    Console.WriteLine($"{wingStar}/ \\{wingStar}");
                }
                else
                {
                    Console.WriteLine($"{wingDash}/ \\{wingDash}");
                }
            }
        }
    }
}
