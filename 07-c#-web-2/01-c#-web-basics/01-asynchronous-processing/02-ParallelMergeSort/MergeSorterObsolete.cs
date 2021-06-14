namespace _02_ParallelMergeSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorterObsolete<T> where T : IComparable<T>
    {
        private IEnumerable<T> Sort(IEnumerable<T> items, int itemsCount)
        {
            if (itemsCount <= 1)
            {
                return items;
            }

            var leftItemsCount = itemsCount / 2;
            var rightItemsCount = itemsCount - leftItemsCount;

            Console.WriteLine("----");
            Console.WriteLine("Left copy: " + string.Join(' ', items.Take(leftItemsCount).ToList()));
            Console.WriteLine("Left copy: " + string.Join(' ', items.Skip(rightItemsCount).ToList()));
            var leftItems = this.Sort(items.Take(leftItemsCount).ToList(), leftItemsCount);
            var rightItems = this.Sort(items.Skip(leftItemsCount).ToList(), rightItemsCount);

            var sortedItems = this.Merge(leftItems, rightItems);

            return sortedItems;
        }

        private IEnumerable<T> Merge(IEnumerable<T> leftItems, IEnumerable<T> rightItems)
        {
            // Console.WriteLine("----");
            // Console.WriteLine("Left: " + string.Join(' ', leftItems));
            // Console.WriteLine("Right: " + string.Join(' ', rightItems));

            var l = leftItems.ToList();
            var r = rightItems.ToList();

            var sortedItems = new List<T>();

            var leftItemsEnumerator = leftItems.GetEnumerator();
            var rightItemsEnumerator = rightItems.GetEnumerator();

            leftItemsEnumerator.MoveNext();
            rightItemsEnumerator.MoveNext();

            while (true)
            {
                var leftItemsCurrent = leftItemsEnumerator.Current;
                var rightItemsCurrent = rightItemsEnumerator.Current;

                // Confusing code. Less confusing than copy-pasting, but needs rethinking
                var (firstItem, secondItem) = (leftItemsCurrent, rightItemsCurrent);
                var (firstItemEnumerator, secondItemEnumerator) = (leftItemsEnumerator, rightItemsEnumerator);

                if (firstItem.CompareTo(secondItem) > 0)
                {
                    (firstItem, secondItem) = (secondItem, firstItem);
                    (firstItemEnumerator, secondItemEnumerator) = (secondItemEnumerator, firstItemEnumerator);
                }

                sortedItems.Add(firstItem);
                var moreItems = firstItemEnumerator.MoveNext();

                if (moreItems == false)
                {
                    var finalItem = secondItemEnumerator.Current;
                    sortedItems.Add(finalItem);

                    break;
                }
            }

            Console.WriteLine("Sorted: " + string.Join(' ', sortedItems));
            Console.WriteLine("----");

            return sortedItems;
        }

        public IEnumerable<T> Sort(IEnumerable<T> items)
        {
            return this.Sort(items, items.Count());
        }
    }
}
