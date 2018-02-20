using System;

namespace _06_number_in_range_1_to_100
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                var num;

                if (int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine($"The number is: #{num}");
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }

            }
        }
    }
}
