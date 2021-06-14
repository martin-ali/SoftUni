namespace _02_ParallelMergeSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> where T : IComparable<T>
    {
        private T[] Sort(T[] items, int start, int count)
        {
            if (count <= 1)
            {
                return items;
            }

            var leftItemsCount = (count / 2) - 1;
            var rightItemsStart = leftItemsCount + 1;
            var rightItemsCount = count - rightItemsStart;

            var leftItems = this.Sort(items, start, leftItemsCount);
            var rightItems = this.Sort(items, rightItemsStart, rightItemsCount);

            var sortedItems = this.Merge(leftItems, rightItems);

            return sortedItems;
        }

        private T[] Merge(T[] leftItems, T[] rightItems)
        {
            return leftItems;
        }

        public T[] Sort(T[] items)
        {
            return this.Sort(items, 0, items.Count());
        }
    }
}
