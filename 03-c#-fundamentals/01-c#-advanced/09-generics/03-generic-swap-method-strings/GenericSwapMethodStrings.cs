using System;
using System.Collections.Generic;

namespace _03_generic_swap_method_strings
{
    class GenericSwapMethodStrings
    {
        static void Main()
        {
            var stringCount = int.Parse(Console.ReadLine());
            var boxes = new List<Box<string>>();
            for (int i = 0; i < stringCount; i++)
            {
                var item = Console.ReadLine();

                var box = new Box<string>(item);

                boxes.Add(box);
            }

            var indicesToSwap = Console.ReadLine().Split();
            var index1 = int.Parse(indicesToSwap[0]);
            var index2 = int.Parse(indicesToSwap[1]);

            Swap(boxes, index1, index2);

            boxes.ForEach(Console.WriteLine);
        }

        private static void Swap<T>(IList<T> items, int index1, int index2)
        {
            var firstItem = items[index1];
            var secondItem = items[index2];

            items[index2] = firstItem;
            items[index1] = secondItem;
        }
    }
}
