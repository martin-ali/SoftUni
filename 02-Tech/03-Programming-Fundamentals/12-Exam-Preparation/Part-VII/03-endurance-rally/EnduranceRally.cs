using System;
using System.Linq;

namespace _03_endurance_rally
{
    class EnduranceRally
    {
        static void Main()
        {
            var drivers = Console.ReadLine().Split(' ');
            var zones = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var checkpoints = Console.ReadLine().Split(' ').Select(double.Parse);

            var points = zones.Select((zone, index) => checkpoints.Contains(index) ? zone : -zone).ToArray();
            foreach (var driver in drivers)
            {
                var fuel = (double)driver[0];
                for (int current = 0; current < points.Length; current++)
                {
                    fuel += points[current];

                    if (fuel <= 0)
                    {
                        Console.WriteLine($"{driver} - reached {current}");
                        break;
                    }
                }

                if (fuel > 0)
                {
                    Console.WriteLine($"{driver} - fuel left {fuel:0.00}");
                }
            }
        }
    }
}
/*

Garry Clark
69 1 15 5
1 2

Garry Clark Larry
4 5 12 0 8 7 13 22 5.5 26
0 3 5 8

Garry
-29 -5.0 -5.0
1 2

 */
