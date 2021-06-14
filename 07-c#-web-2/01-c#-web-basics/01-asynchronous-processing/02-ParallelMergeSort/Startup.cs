namespace _02_ParallelMergeSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var randomItems = GetRandomizedCollection(11);

            Console.WriteLine("Unsorted");
            Console.WriteLine(string.Join(' ', randomItems));

            var sorter = new MergeSorterObsolete<int>();
            var sortedItems = sorter.Sort(randomItems);

            Console.WriteLine("Merge sorted");
            Console.WriteLine(string.Join(' ', sortedItems));

            Console.WriteLine("Dotnet sorted");
            Console.WriteLine(string.Join(' ', randomItems.OrderBy(x => x)));
        }

        private static IEnumerable<int> GetRandomizedCollection(int count)
        {
            var random = new Random();
            var items = Enumerable.Range(1, count).OrderBy(x => random.Next());

            return items;
        }
    }
}
