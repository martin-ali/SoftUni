using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_truck_tour
{
    class TruckTour
    {
        static void Main()
        {
            var petrolPumpCount = int.Parse(Console.ReadLine());

            var circle = new Queue<int>();
            for (int i = 0; i < petrolPumpCount; i++)
            {
                var pumpParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var pump = pumpParameters[0] - pumpParameters[1];

                circle.Enqueue(pump);
            }

            for (int currentRoute = 0; currentRoute < petrolPumpCount; currentRoute++)
            {
                var fuelTankCapacity = 0;
                var circleCanBeCompleted = true;

                foreach (var pump in circle)
                {
                    fuelTankCapacity += pump;

                    if (fuelTankCapacity < 0)
                    {
                        circleCanBeCompleted = false;
                        break;
                    }
                }

                // Start at a different pump every time
                var endPoint = circle.Dequeue();
                circle.Enqueue(endPoint);

                if (circleCanBeCompleted)
                {
                    Console.WriteLine(currentRoute);
                    break;
                }
            }
        }
    }
}
/*
3
1 5
10 3
3 4
*/
