using System;
using System.Collections.Generic;

namespace _03_periodic_table
{
    class PeriodicTable
    {
        static void Main()
        {
            var elementsCount = int.Parse(Console.ReadLine());
            var elements = new SortedSet<string>();

            for (int i = 0; i < elementsCount; i++)
            {
                elements.UnionWith(Console.ReadLine().Split());
            }

            Console.WriteLine(string.Join(' ', elements));
        }
    }
}
