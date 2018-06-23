using System;

namespace wormtest
{
    class Program
    {
        static void Main()
        {
            long length = long.Parse(Console.ReadLine()) * 100;
            decimal width = decimal.Parse(Console.ReadLine());

            var remainder = (length != 0 && width != 0)
                                ? length % width
                                : 0;

            if (remainder == 0)
            {
                Console.WriteLine($"{length * width:0.00}");
            }
            else
            {
                decimal result = 1 / (width / length) * 100;
                Console.WriteLine($"{result:0.00}%");
            }
        }
    }
}
