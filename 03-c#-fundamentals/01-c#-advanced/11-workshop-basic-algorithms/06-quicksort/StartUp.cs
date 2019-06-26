using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_quicksort
{
    class StartUp
    {
        static void Main()
        {
            // var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // var items = new[] { 9, 8, 7, 6, 5, 4, 7, 7, 5, 7, 3, 2, 1 };
            // var items = new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            // var items = new[] { 23445, 6, 7, 6, 543, 4324, 56, 6, 78, 6786, 544, 354546, 567, 567643, 3, 3, 56, 7 };
            // var items = new[] { 4, 6, 8, 9, 0, 0, 0, -1, -1, -2342, 2123, 2, 3, 57, 8, 9 };
            var items = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();
            var sorter = new QuickSorter<int>();
            sorter.Sort(items);

            Console.WriteLine(string.Join(' ', items));
            // Console.WriteLine(string.Join(' ', items.OrderBy(x => x)));
        }

        public class QuickSorter<T> where T : IComparable<T>
        {
            public void Sort(T[] items)
            {
                Sort(items, 0, items.Length - 1);
            }

            // TODO: Improve memory usage
            // TODO: Improve performance
            private void Sort(T[] items, int start, int end)
            {
                // if (items.Length == 1)
                if (start >= end)
                {
                    return;
                }

                var middle = (start + end) / 2;
                var pivot = items[middle];

                var smallerAndEqual = new Queue<T>();
                var bigger = new Queue<T>();

                for (int i = start; i <= end; i++)
                {
                    if (i == middle) continue;
                    var item = items[i];
                    if (item.CompareTo(pivot) < 0)
                    {
                        smallerAndEqual.Enqueue(item);
                    }
                    else
                    {
                        bigger.Enqueue(item);
                    }
                }

                // Sort left partition
                var index = start;
                foreach (var item in smallerAndEqual)
                {
                    items[index++] = item;
                }

                // Plug in middle(pivot)
                items[index++] = pivot;

                // Sort right partition
                foreach (var item in bigger)
                {
                    items[index++] = item;
                }

                var x = smallerAndEqual.Count;

                Sort(items, start, start + x - 1);
                Sort(items, start + x + 1, end);
            }
        }
    }
}