using System;

namespace _04_even_powers_of_2
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            for (int current = 0; current <= num; current+=2)
            {
                Console.WriteLine(Math.Pow(2, current));
            }
        }
    }
}
