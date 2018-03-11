using System;
using System.Linq;

namespace histogram
{
    class Program
    {

        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            var numbers = new int[size];

            for (int i = 0; i < size; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // Lol, LINQ
            var numbersUnder200 = (numbers.Where(x => x < 200).Count() / (double)size) * 100;
            var numbersBetween200And399 = (numbers.Where(x => 200 <= x && x <= 399).Count() / (double)size) * 100;
            var numbersBetween400And599 = (numbers.Where(x => 400 <= x && x <= 599).Count() / (double)size) * 100;
            var numbersBetween600And799 = (numbers.Where(x => 600 <= x && x <= 799).Count() / (double)size) * 100;
            var numbersOver799 = (numbers.Where(x => x >= 800).Count() / (double)size) * 100;

            Console.WriteLine($"{numbersUnder200:0.00}%");
            Console.WriteLine($"{numbersBetween200And399:0.00}%");
            Console.WriteLine($"{numbersBetween400And599:0.00}%");
            Console.WriteLine($"{numbersBetween600And799:0.00}%");
            Console.WriteLine($"{numbersOver799:0.00}%");
        }
    }
}
