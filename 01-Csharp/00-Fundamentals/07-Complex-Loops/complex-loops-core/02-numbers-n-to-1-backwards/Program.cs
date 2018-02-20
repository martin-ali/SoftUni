using System;

namespace _02_numbers_n_to_1_backwards
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            for (int current = num; current >= 1; current--)
            {
                Console.WriteLine(current);
            }
        }
    }
}
