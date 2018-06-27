using System;
using System.Globalization;
using System.Numerics;

namespace _01_sino_the_walker
{
    class SinoTheWalker
    {
        static void Main()
        {
            var secondsInDay = 24 * 60 * 60;
            var departure = TimeSpan.Parse(Console.ReadLine());
            var numberOfSteps = int.Parse(Console.ReadLine()) % secondsInDay;
            var secondsPerStep = int.Parse(Console.ReadLine()) % secondsInDay;

            var secondsToHome = numberOfSteps * secondsPerStep;
            var arrival = departure + TimeSpan.FromSeconds(secondsToHome);

            Console.WriteLine($"Time Arrival: {arrival:hh\\:mm\\:ss}");
        }
    }
}
/*

12:30:30
90
1

23:49:13
5424
2

 */
