namespace _02_parallel_merge_sort
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            var items = new List<int>() { 1, 6, 8, 4, 2, 4, 7, 8, 5, 3, 2, 334, 45, 7, 86, 4423, 122, 1212, 46, 77 };

            var sorter = new ParallelMergeSorter<int>();
            var sortedItems = sorter.Sort(items);

            Console.WriteLine(string.Join(' ', sortedItems));
            Console.WriteLine("Hello World!");
        }
    }
}
