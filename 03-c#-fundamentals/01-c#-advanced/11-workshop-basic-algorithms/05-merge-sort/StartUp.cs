using System;
using System.Linq;

namespace _05_merge_sort
{
    class StartUp
    {
        static void Main()
        {
            // var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // var items = new[] { 9, 8, 7, 6, 5, 4, 7, 7, 5, 7, 3, 2, 1 };
            var items = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();

            var sorter = new MergeSorter<int>();
            var sorted = sorter.Sort(items);

            Console.WriteLine(string.Join(' ', sorted));
        }
    }

    public class MergeSorter<T> where T : IComparable<T>
    {
        public T[] Sort(T[] items)
        {
            if (items.Length <= 1)
            {
                return items;
            }

            var middle = items.Length / 2;

            var firstHalf = new T[middle];
            var secondHalf = new T[items.Length - middle];

            Array.ConstrainedCopy(items, 0, firstHalf, 0, middle);
            Array.ConstrainedCopy(items, middle, secondHalf, 0, items.Length - middle);

            firstHalf = this.Sort(firstHalf);
            secondHalf = this.Sort(secondHalf);

            var sorted = this.Merge(firstHalf, secondHalf);

            return sorted;
        }

        private T[] Merge(T[] left, T[] right)
        {
            var mergedItems = new T[left.Length + right.Length];

            var leftIndex = 0;
            var rightIndex = 0;

            while (leftIndex < left.Length
                || rightIndex < right.Length)
            {
                var mergedIndex = leftIndex + rightIndex;
                if (leftIndex < left.Length && rightIndex < right.Length)
                {
                    var leftItemPrecedesRight = left[leftIndex].CompareTo(right[rightIndex]) < 0;
                    if (leftItemPrecedesRight)
                    {
                        mergedItems[mergedIndex] = left[leftIndex++];
                    }
                    else
                    {
                        mergedItems[mergedIndex] = right[rightIndex++];
                    }
                }
                else if (leftIndex < left.Length)
                {
                    mergedItems[mergedIndex] = left[leftIndex++];
                }
                else if (rightIndex < right.Length)
                {
                    mergedItems[mergedIndex] = right[rightIndex++];
                }
            }

            return mergedItems;
        }
    }
}
