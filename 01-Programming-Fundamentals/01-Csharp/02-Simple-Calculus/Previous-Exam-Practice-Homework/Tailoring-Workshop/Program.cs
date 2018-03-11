using System;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main()
        {
            decimal numberOfTables = int.Parse(Console.ReadLine());
            decimal tableLengthInMeters = decimal.Parse(Console.ReadLine());
            decimal tableWidthInMeters = decimal.Parse(Console.ReadLine());

            decimal totalFabricLength = tableLengthInMeters + 0.6m;
            decimal totalFabricWidth = tableWidthInMeters + 0.6m;

            decimal PokrivkaArea = numberOfTables * totalFabricLength * totalFabricWidth;
            decimal kareArea = numberOfTables * (tableLengthInMeters / 2) * (tableLengthInMeters / 2);

            decimal pokrivkaPrice = PokrivkaArea * 7;
            decimal karePrice = kareArea * 9;

            decimal resultInUsd = pokrivkaPrice + karePrice;
            var resultInBgn = resultInUsd * 1.85m;

            Console.WriteLine($"{resultInUsd:0.00} USD\n{resultInBgn.ToString("0.00")} BGN");
        }
    }
}