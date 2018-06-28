using System;

namespace _01_splinter_trip
{
    class SplinterTip
    {
        static void Main()
        {
            const int FuelConsumption = 25;
            const double FuelConsumptionInHeavyWinds = 25.0 * 1.5;

            var distance = double.Parse(Console.ReadLine());
            var fuelCapacity = double.Parse(Console.ReadLine());
            var milesSpentInHeavyWinds = double.Parse(Console.ReadLine());

            var milesSpentInWeakWinds = distance - milesSpentInHeavyWinds;
            var fuelNeeded = ((milesSpentInWeakWinds * FuelConsumption) + (milesSpentInHeavyWinds * FuelConsumptionInHeavyWinds)) * 1.05;

            Console.WriteLine($"Fuel needed: {fuelNeeded:0.00}L");

            if (fuelCapacity >= fuelNeeded)
            {
                var remainingFuel = fuelCapacity - fuelNeeded;
                Console.WriteLine($"Enough with {remainingFuel:0.00}L to spare!");
            }
            else
            {
                var fuelMissing = fuelNeeded - fuelCapacity;
                Console.WriteLine($"We need {fuelMissing:0.00}L more fuel.");
            }
        }
    }
}
/*

500.5
14000
50

9000
235000
230

1000
26250
0

 */
