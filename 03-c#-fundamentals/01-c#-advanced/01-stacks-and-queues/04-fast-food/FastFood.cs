using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_fast_food
{
    class FastFood
    {
        static void Main()
        {
            var foodReserve = int.Parse(Console.ReadLine());
            var pendingOrders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var biggestOrder = pendingOrders.Max();

            while (pendingOrders.Count > 0)
            {
                var currentOrder = pendingOrders.Peek();
                if (foodReserve >= currentOrder)
                {
                    pendingOrders.Dequeue();
                    foodReserve -= currentOrder;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(biggestOrder);
            if (pendingOrders.Count == 0)
            {
                Console.WriteLine($"Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(' ', pendingOrders)}");
            }
        }
    }
}
