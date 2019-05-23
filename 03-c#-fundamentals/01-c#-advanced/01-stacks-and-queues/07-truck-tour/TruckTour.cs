using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07_truck_tour
{
    class TruckTour
    {
        static void Main()
        {
            var pumps = new Queue<(int capacity, int distanceToNext)>();
            var pumpCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < pumpCount; i++)
            {
                var pumpInfo = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
                var pump = (capacity: pumpInfo[0], distanceToNext: pumpInfo[1]);
                pumps.Enqueue(pump);
            }

            for (int route = 0; route < pumps.Count; route++)
            {
                var truckFuel = 0;
                var routeCanBeCompleted = true;

                foreach (var pump in pumps)
                {
                    truckFuel += pump.capacity;
                    truckFuel -= pump.distanceToNext;

                    if (truckFuel < 0)
                    {
                        routeCanBeCompleted = false;
                        break;
                    }
                }

                var firstPump = pumps.Dequeue();
                pumps.Enqueue(firstPump);

                if (routeCanBeCompleted)
                {
                    Console.WriteLine(route);
                    break;
                }
            }
        }
    }
}
