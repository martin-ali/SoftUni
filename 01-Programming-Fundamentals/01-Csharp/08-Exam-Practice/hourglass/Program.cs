using System;

namespace hourglass
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            // int n = 3;
            var lineSize = 2 * n + 1;

            // Draw top line
            Console.WriteLine(new String('*', lineSize));

            // Draw second line
            Console.WriteLine($".*{new String(' ', lineSize - 4)}*.");

            // Draw upper part
            var dotsSize = 2;
            for (int row = 0; row < n - 2; row++, dotsSize++)
            {
                var dots = new String('.', dotsSize);
                var sand = new String('@', lineSize - (dotsSize * 2) - 2);

                Console.WriteLine($"{dots}*{sand}*{dots}");
            }

            // Draw center
            var centerDots = new String('.', dotsSize);
            Console.WriteLine($"{centerDots}*{centerDots}");

            // Draw Bottom part
            dotsSize--;
            for (int row = 0; row < n - 2; row++, dotsSize--)
            {
                var airSize = (lineSize - (dotsSize * 2) - 3) / 2;
                var dots = new String('.', dotsSize);
                var air = new String(' ', airSize);

                Console.WriteLine($"{dots}*{air}@{air}*{dots}");
            }

            // Draw second-lowest line
            Console.WriteLine($".*{new String('@', lineSize - 4)}*.");

            // Draw bottom line
            Console.WriteLine(new String('*', lineSize));
        }
    }
}
