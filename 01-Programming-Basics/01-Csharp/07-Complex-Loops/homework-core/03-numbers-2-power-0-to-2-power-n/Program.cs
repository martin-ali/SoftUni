using System;

namespace _03_numbers_2_power_0_to_2_power_n
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            for (int current = 0; current <= num; current++)
            {
                Console.WriteLine(Math.Pow(2, current));
            }
        }
    }
}
