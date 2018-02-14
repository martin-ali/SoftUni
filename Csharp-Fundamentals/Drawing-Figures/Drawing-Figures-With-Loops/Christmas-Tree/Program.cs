using System;

namespace Christmas_Tree
{
    class Program
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            for (int current = 0; current <= size; current++)
            {
                var leaves = new string('*', current);
                var padding = new string(' ', size - leaves.Length);
                Console.WriteLine($"{padding}{leaves} | {leaves}");
            }
        }
    }
}
