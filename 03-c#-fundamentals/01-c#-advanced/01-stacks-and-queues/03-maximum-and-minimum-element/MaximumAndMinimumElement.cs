using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_maximum_and_minimum_element
{
    class MaximumAndMinimumElement
    {
        static void Main()
        {
            var items = new Stack<int>();
            var itemsCount = int.Parse(Console.ReadLine());
            for (int current = 0; current < itemsCount; current++)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];

                if (command == "1")
                {
                    var itemToPush = int.Parse(input[1]);
                    items.Push(itemToPush);
                }
                else if (command == "2" && items.Count != 0)
                {
                    items.Pop();
                }
                else if (command == "3" && items.Count != 0)
                {
                    Console.WriteLine(items.Max());
                }
                else if (command == "4" && items.Count != 0)
                {
                    Console.WriteLine(items.Min());
                }
            }

            Console.WriteLine(string.Join(", ", items));
        }
    }
}
