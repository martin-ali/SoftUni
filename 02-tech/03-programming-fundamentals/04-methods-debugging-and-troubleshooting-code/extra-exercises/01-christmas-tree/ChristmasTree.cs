using System;

namespace _01_christmas_tree
{
    class ChristmasTree
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            for (int i = 0; i <= size; i++)
            {
                var leaves = new string('*', i);
                var padding = new string(' ', size - i);
                Console.WriteLine($"{padding}{leaves} | {leaves}");
            }
        }
    }
}
