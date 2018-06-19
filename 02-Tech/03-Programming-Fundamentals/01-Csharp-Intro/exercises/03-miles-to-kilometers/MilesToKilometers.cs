using System;

namespace _03_miles_to_kilometers
{
    class MilesToKilometers
    {
        static void Main()
        {
            double numberInMiles = double.Parse(Console.ReadLine());
            double numberInKilometers = numberInMiles * 1.60934d;
            Console.WriteLine(Math.Round(numberInKilometers, 2));
        }
    }
}
