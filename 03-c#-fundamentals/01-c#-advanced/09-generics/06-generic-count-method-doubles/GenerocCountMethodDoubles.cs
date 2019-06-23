using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_generic_count_method_doubles
{
    class GenerocCountMethodDoubles
    {
        static void Main()
        {
            var stringCount = int.Parse(Console.ReadLine());
            var items = new List<Box<double>>();

            for (int i = 0; i < stringCount; i++)
            {
                var item = double.Parse(Console.ReadLine());

                var box = new Box<double>(item);

                items.Add(box);
            }

            var comparisonItem = new Box<double>(double.Parse(Console.ReadLine()));
            var biggerItemsCount = items.Count(x => x.CompareTo(comparisonItem) > 0);

            Console.WriteLine(biggerItemsCount);
        }
    }
}
