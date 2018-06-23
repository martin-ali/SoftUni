using System;

namespace _17_print_part_of_the_ascii_table
{
    class PrintPartOfTheAsciiTable
    {
        static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int current = start; current <= end; current++)
            {
                Console.Write((char)current + " ");
            }
        }
    }
}
