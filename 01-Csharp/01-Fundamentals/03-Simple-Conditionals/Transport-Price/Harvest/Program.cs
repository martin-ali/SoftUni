using System;

namespace Harvest
{
    class Program
    {
        static void Main()
        {
            var vineyardArea = int.Parse(Console.ReadLine());
            var grapesPerSqM = double.Parse(Console.ReadLine());
            var targetWineInLiters = int.Parse(Console.ReadLine());
            var numberOfWorkers = int.Parse(Console.ReadLine());

            double grapesForWine = (vineyardArea * 0.4) * grapesPerSqM;
            double wineProducedInLiters = grapesForWine / 2.5;

            if (wineProducedInLiters >= targetWineInLiters)
            {
                double leftoverWine = wineProducedInLiters - targetWineInLiters;
                double winePerPerson = leftoverWine / numberOfWorkers;

                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineProducedInLiters)} liters.");
                Console.WriteLine($"{Math.Ceiling(leftoverWine)} liters left -> {Math.Ceiling(winePerPerson)} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(targetWineInLiters - wineProducedInLiters)} liters wine needed.");
            }
        }
    }
}
