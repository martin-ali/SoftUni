using System;

namespace _01_numbers_1_to_n_with_step_3
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            for (int current = 1; current <= num; current+=3)
            {
                System.Console.WriteLine(current);
            }            
        }
    }
}
