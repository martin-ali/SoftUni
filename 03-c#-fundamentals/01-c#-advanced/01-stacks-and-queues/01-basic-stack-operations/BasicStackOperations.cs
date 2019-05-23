using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_basic_stack_operations
{
    class BasicStackOperations
    {
        static void Main()
        {
            var parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var itemsCountToPush = parameters[0];
            var itemsToPop = parameters[1];
            var itemToFind = parameters[2];

            var inputItems = Console.ReadLine().Split().Select(int.Parse);
            var items = new Stack<int>(inputItems);

            for (int i = 0; i < itemsToPop; i++)
            {
                if (items.Count == 0) { break; }

                items.Pop();
            }

            if (items.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (items.Contains(itemToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(items.Min());
            }
        }
    }
}
