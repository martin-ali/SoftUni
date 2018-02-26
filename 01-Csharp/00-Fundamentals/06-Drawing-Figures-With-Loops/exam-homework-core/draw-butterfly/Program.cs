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
            int wingWidth = size - 2;
            string wingStar = new String('*', wingWidth);
            string wingDash = new String('-', wingWidth);
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
            Console.WriteLine($"{new String(' ', size - 1)}@");

            // Draw bottom
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
