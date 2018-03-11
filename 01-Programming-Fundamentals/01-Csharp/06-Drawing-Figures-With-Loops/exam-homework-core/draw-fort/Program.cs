using System;

namespace draw_fort
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            // Draw top
            var widthBetweenTowers = (2 * size) - 4 - ((size / 2) * 2);
            string towerTop = new String('^', size / 2);
            string topMiddleSection = new String('_', widthBetweenTowers);
            Console.WriteLine($"/{towerTop}\\{topMiddleSection}/{towerTop}\\");

            // Draw midsection
            for (int row = 2; row < size; row++)
            {
                if (row == size - 1)
                {
                    var emptySpaceWidth = ((size * 2) - 2 - widthBetweenTowers) / 2;
                    string wall = new String(' ', emptySpaceWidth);
                    string bottomSectionBetweenTowers = new String('_', widthBetweenTowers);
                    Console.WriteLine($"|{wall}{bottomSectionBetweenTowers}{wall}|");
                }
                else
                {
                    string wall = new String(' ', (size * 2) - 2);
                    Console.WriteLine($"|{wall}|");
                }
            }

            // Draw bottom
            string towerBottom = new String('_', size / 2);
            string bottomMiddleSection = new String(' ', widthBetweenTowers);
            Console.WriteLine($"\\{towerBottom}/{bottomMiddleSection}\\{towerBottom}/");
        }
    }
}
