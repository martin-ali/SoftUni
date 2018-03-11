using System;

namespace mask
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int lineSize = (2 * n) + 2;
            int height = n * 3 + 2;

            // Draw top
            for (int i = 0; i < n - 1; i++)
            {
                var whitespace = new String(' ', i);
                var padding = new String(' ', n - 2 - i);
                Console.WriteLine($"{padding}/{whitespace}|  |{whitespace}\\");
            }

            // Draw line
            Console.WriteLine(new String('-', lineSize));

            // Draw brows & eyes
            var eyeSeparator = new String(' ', n + 1);
            var eyeSpace = new String(' ', (lineSize - 4 - eyeSeparator.Length) / 2);
            Console.WriteLine($"|{eyeSpace}_{eyeSeparator}_{eyeSpace}|");
            Console.WriteLine($"|{eyeSpace}@{eyeSeparator}@{eyeSpace}|");

            // Draw midsection
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine($"|{new String(' ', lineSize - 2)}|");
            }

            // Draw nostrils
            var nostrilSpace = new String(' ', (lineSize - 4) / 2);
            Console.WriteLine($"|{nostrilSpace}OO{nostrilSpace}|");

            // Draw nose & moustache
            var noseSpace = new String(' ', (lineSize - 6) / 2);
            Console.WriteLine($"|{noseSpace}/  \\{noseSpace}|");
            Console.WriteLine($"|{noseSpace}||||{noseSpace}|");

            // Draw bottom
            for (int i = 0; i <= n; i++)
            {
                var dots = new String('`', lineSize - 2 - i - i);
                var linesLeft = new String('\\', i + 1);
                var linesRight = new String('/', i + 1);
                Console.WriteLine($"{linesLeft}{dots}{linesRight}");
            }
        }
    }
}
