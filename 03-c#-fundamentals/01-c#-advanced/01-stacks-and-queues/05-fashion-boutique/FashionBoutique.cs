using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_fashion_boutique
{
    class FashionBoutique
    {
        static void Main()
        {
            var clothes = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var rackCapacity = int.Parse(Console.ReadLine());

            var racksUsed = 1;
            var currentRackCapacityLeft = rackCapacity;
            while (clothes.Count > 0)
            {
                var currentClothing = clothes.Peek();

                if (currentRackCapacityLeft >= currentClothing)
                {
                    currentRackCapacityLeft -= currentClothing;
                    clothes.Dequeue();
                }
                else
                {
                    racksUsed++;
                    currentRackCapacityLeft = rackCapacity;
                }
            }

            Console.WriteLine(racksUsed);
        }
    }
}
