using System;

namespace Simple_Conditionals_II
{
    class Program
    {
        private static decimal taxiStartTax = 0.70m;
        private static decimal taxiDayPrice = 0.79m;
        private static decimal taxiNightPrice = 0.90m;

        private static int bisMinTravelLength = 20;
        private static decimal busBricing = 0.09m;

        private static int trainMinTravelLength = 100;
        private static decimal trainPricing = 0.06m;

        static void Main()
        {

            var travelLength = int.Parse(Console.ReadLine());
            var timeOfDay = Console.ReadLine();

            decimal priceOfTaxiFare = decimal.MaxValue;
            decimal priceOfBusFare = decimal.MaxValue;
            decimal priceOfTrainFare = decimal.MaxValue;

            decimal taxiPriceForTravel = travelLength * (timeOfDay == "day" ? taxiDayPrice : taxiNightPrice);
            priceOfTaxiFare = taxiStartTax + taxiPriceForTravel;

            if (travelLength >= 20)
            {
                priceOfBusFare = travelLength * busBricing;
            }

            if (travelLength >= 100)
            {
                priceOfTrainFare = travelLength * trainPricing;
            }

            decimal result = Math.Min(Math.Min(priceOfTaxiFare, priceOfBusFare), priceOfTrainFare);
            Console.WriteLine($"{result:0.00}");
        }
    }
}
