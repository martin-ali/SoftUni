using System;

namespace _10_sum_of_chars
{
    class SumOfChars
    {
        static void Main()
        {
            var sum = 0;
            var numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                var character = char.Parse(Console.ReadLine());
                sum += character;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
