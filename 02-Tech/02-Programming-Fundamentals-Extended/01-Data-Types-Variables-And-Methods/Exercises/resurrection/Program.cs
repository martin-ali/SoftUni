using System;

namespace resurrection
{
    class Program
    {
        static void Main()
        {
            int numberOfPhoenixes = int.Parse(Console.ReadLine());

            while (numberOfPhoenixes-- > 0)
            {
                var bodyLength = long.Parse(Console.ReadLine());
                var bodyWidth = decimal.Parse(Console.ReadLine());
                var wingLength = long.Parse(Console.ReadLine());

                var phoenix = (length: bodyLength, width: bodyWidth, wingLength: wingLength);
                var yearsToReincarnate = (phoenix.length * phoenix.length) * (phoenix.width + (2 * phoenix.wingLength));

                Console.WriteLine(yearsToReincarnate);
            }
        }
    }
}
