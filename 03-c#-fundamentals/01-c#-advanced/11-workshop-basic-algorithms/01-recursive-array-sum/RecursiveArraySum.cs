using System;
using System.Linq;

namespace _01_recursive_array_sum
{
    class RecursiveArraySum
    {
        static void Main()
        {
            var items = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();

            var sum = Sum(items);
            Console.WriteLine(sum);
        }

        private static int Sum(int[] items, int index = 0)
        {
            if (index >= items.Length)
            {
                return 0;
            }

            var sum = items[index] + Sum(items, index + 1);

            return sum;
        }
    }
}
