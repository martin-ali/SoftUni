using System;

namespace _05_diamond
{
    class Diamond
    {
        static void Main()
        {
            //var size = 15;
            var size = int.Parse(Console.ReadLine());

            var roofSize = Math.Ceiling(size / 2m);
            var baseSize = (int)Math.Floor(size / 2m);

            // Draw top
            var lastRowLength = 0;
            for (int current = 0, roofCurrentWidth = size % 2 == 0 ? 2 : 1; current < roofSize; current++, roofCurrentWidth += 2)
            {
                var diamond = "*";
                var dashes = new string('-', (size - roofCurrentWidth) / 2);

                if (roofCurrentWidth >= 2)
                {
                    diamond = $"*{new string('-', roofCurrentWidth - 2)}*";
                }

                Console.WriteLine($"{dashes}{diamond}{dashes}");
                lastRowLength = roofCurrentWidth;
            }

            // Draw bottom
            for (int current = lastRowLength - 2; current > 0; current -= 2)
            {
                var diamond = "*";
                var dashes = new string('-', (size - current) / 2);

                if (current >= 2)
                {
                    diamond = $"*{new string('-', current - 2)}*";
                }

                Console.WriteLine($"{dashes}{diamond}{dashes}");
            }
        }
    }
}
