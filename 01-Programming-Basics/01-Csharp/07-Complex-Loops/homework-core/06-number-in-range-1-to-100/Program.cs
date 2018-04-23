using System;

namespace _06_number_in_range_1_to_100
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                var num = int.Parse(Console.ReadLine());

                if (1 <= num && num <= 100)
                {
                    Console.WriteLine($"The number is: {num}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }
    }
}
