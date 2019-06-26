using System;
using System.Linq;

namespace _07_binary_search
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();
            var numberToFind = int.Parse(Console.ReadLine());

            var result = BinarySearch(numbers, numberToFind);
            Console.WriteLine(result);
        }

        private static int BinarySearch(int[] items, int itemToFind)
        {
            var start = 0;
            var end = items.Length - 1;
            while (start <= end)
            {
                var index = (start + end) / 2;
                var item = items[index];

                if (item == itemToFind)
                {
                    return index;
                }
                else if (item < itemToFind)
                {
                    start = index + 1;
                }
                else if (item > itemToFind)
                {
                    end = index - 1;
                }
            }

            return -1;
        }
    }
}
