using System;
using System.Linq;

namespace division_without_remainder
{
    class Program
    {
        // Wtf, copy-paste :/
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            var numbers = new int[size];

            for (int i = 0; i < size; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            var numbersDivisibleBy2 = (numbers.Where(x => x % 2 == 0).Count() / (double)size) * 100;
            var numbersDivisibleBy3 = (numbers.Where(x => x % 3 ==0).Count() / (double)size) * 100;
            var numbersDivisibleBy4 = (numbers.Where(x => x % 4 == 0).Count() / (double)size) * 100;

            Console.WriteLine($"{numbersDivisibleBy2:0.00}%");
            Console.WriteLine($"{numbersDivisibleBy3:0.00}%");
            Console.WriteLine($"{numbersDivisibleBy4:0.00}%");
        }
    }
}
