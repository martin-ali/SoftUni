namespace _02_parallel_merge_sort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParallelMergeSorter<T> where T : IComparable
    {
        public IEnumerable<T> Sort(IEnumerable<T> items)
        {
            return this.Split(items);
        }

        private IEnumerable<T> Split(IEnumerable<T> items)
        {
            var length = items.Count();

            if (length == 1)
            {
                return items;
            }

            var middle = items.Skip(length / 2).First();

            var left = items.Where(x => x.CompareTo(middle) < 0);
            var matches = items.Where(x => x.CompareTo(middle) == 0);
            var right = items.Where(x => x.CompareTo(middle) > 0);

            left = Split(left);
            right = Split(right);

            var merged = this.Merge(left, right);

            return items;
        }

        private IEnumerable<T> Merge(IEnumerable<T> left, IEnumerable<T> right)
        {
            var length = left.Count() + right.Count();
            var index = 0;
            var mergedItems = new T[length];

            var leftEnumerator = left.GetEnumerator();
            var rightEnumerator = left.GetEnumerator();
            var reachedEnd = false;
            while (true)
            {
                var leftItem = leftEnumerator.Current;
                var rightItem = rightEnumerator.Current;

                if (leftItem.CompareTo(rightItem) < 0)
                {
                    mergedItems[index] = leftItem;
                    reachedEnd &= !leftEnumerator.MoveNext();
                }
                else
                {
                    mergedItems[index] = rightItem;
                    reachedEnd &= !rightEnumerator.MoveNext();
                }

                if (reachedEnd)
                {
                    break;
                }

                index++;
            }

            return mergedItems;
        }
    }
}