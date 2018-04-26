using System;

namespace _11_convert_speed_units
{
    class ConvertSpeedUnits
    {
        static void Main()
        {
            decimal distanceInMeters = decimal.Parse(Console.ReadLine());
            decimal hours = decimal.Parse(Console.ReadLine());
            decimal minutes = decimal.Parse(Console.ReadLine());
            decimal seconds = decimal.Parse(Console.ReadLine());

            decimal overallTimeInSeconds = (((hours * 60) + minutes) * 60) + seconds;
            decimal speedInMetersPerSecond = distanceInMeters / overallTimeInSeconds;
            decimal speedInKilometersPerHour = speedInMetersPerSecond * 3.6m; ;
            decimal speedInMilesPerHour = speedInKilometersPerHour / 1.609m;

            Console.WriteLine($"{(float)speedInMetersPerSecond}");
            Console.WriteLine($"{(float)speedInKilometersPerHour}");
            Console.WriteLine($"{(float)speedInMilesPerHour}");
        }
    }
}
