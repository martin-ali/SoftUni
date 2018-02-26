using System;

namespace draw_stop_sign
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int firstSectionHeight = size + 1;
            int signHeight = (firstSectionHeight * 2) + 1;
            int signWidth = (size + 1) + ((size * 2) + 1) + (size + 1);

            // Draw top
            int dotSectionWidth = size + 1;
            int underscoreSectionWidth = (size * 2) + 1;
            for (int row = 0; row < firstSectionHeight; row++, dotSectionWidth--, underscoreSectionWidth += 2)
            {
                var dots = new String('.', dotSectionWidth);
                if (row > 0)
                {
                    var underscores = new String('_', underscoreSectionWidth - 4);
                    Console.WriteLine($"{dots}//{underscores}\\\\{dots}");
                }
                else
                {
                    var underscores = new String('_', underscoreSectionWidth);
                    Console.WriteLine($"{dots}{underscores}{dots}");
                }
            }

            // Draw mid
            // 4 diagonal lines, 5 letters in "STOP!"
            var side = new String('_', (signWidth - 4 - 5) / 2);
            Console.WriteLine($"//{side}STOP!{side}\\\\");

            // Draw bottom
            for (int row = size; row > 0; row--, dotSectionWidth++, underscoreSectionWidth -= 2)
            {
                var dots = new String('.', dotSectionWidth);
                var undescores = new String('_', underscoreSectionWidth - 4);
                Console.WriteLine($"{dots}\\\\{undescores}//{dots}");
            }
        }
    }
}