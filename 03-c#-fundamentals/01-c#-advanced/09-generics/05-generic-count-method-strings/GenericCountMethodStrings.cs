using System;
using System.Linq;
using System.Collections.Generic;

namespace _05_generic_count_method_strings
{
    class GenericCountMethodStrings
    {
        static void Main()
        {
            var stringCount = int.Parse(Console.ReadLine());
            var items = new List<Box<string>>();

            for (int i = 0; i < stringCount; i++)
            {
                var item = Console.ReadLine();

                var box = new Box<string>(item);

                items.Add(box);
            }

            var comparisonItem = new Box<string>(Console.ReadLine());
            var biggerItemsCount = items.Count(x => x.CompareTo(comparisonItem) > 0);

            Console.WriteLine(biggerItemsCount);
        }
    }
}
