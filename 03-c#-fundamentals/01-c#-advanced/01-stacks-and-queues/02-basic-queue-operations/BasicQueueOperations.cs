using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_basic_queue_operations
{
    class BasicQueueOperations
    {
        static void Main()
        {
            var parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var itemsCountToEnqueue = parameters[0];
            var itemsToDequeue = parameters[1];
            var itemToFind = parameters[2];

            var inputItems = Console.ReadLine().Split().Select(int.Parse);
            var items = new Queue<int>(inputItems);

            for (int i = 0; i < itemsToDequeue; i++)
            {
                if (items.Count == 0) { break; }

                items.Dequeue();
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
