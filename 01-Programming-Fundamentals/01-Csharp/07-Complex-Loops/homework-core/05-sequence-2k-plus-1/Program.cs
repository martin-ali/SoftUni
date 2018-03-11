using System;

namespace _05_sequence_2k_plus_1
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var previous = 1;

            while (previous <= num)
            {
                Console.WriteLine(previous);
                previous = (previous * 2) + 1;
            }
        }
    }
}
