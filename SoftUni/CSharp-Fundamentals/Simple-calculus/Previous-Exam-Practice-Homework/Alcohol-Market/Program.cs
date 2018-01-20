using System;

namespace Alcohol_Market
{
    class Program
    {
        static void Main()
        {
            //var whiskeyPrice = 50;
            //var beerAmount = 10;
            //var wineAmount = 3.5m;
            //var rakiqAmount = 6.5m;
            //var whiskeyAmount = 1;

            var whiskeyPrice = decimal.Parse(Console.ReadLine());
            var beerAmount = decimal.Parse(Console.ReadLine());
            var wineAmount = decimal.Parse(Console.ReadLine());
            var rakiqAmount = decimal.Parse(Console.ReadLine());
            var whiskeyAmount = decimal.Parse(Console.ReadLine());

            var rakiqPrice = whiskeyPrice / 2;
            var winePrice = rakiqPrice * 0.6m;
            var beerPrice = rakiqPrice * 0.2m;

            var whiskeyTotalPrice = whiskeyAmount * whiskeyPrice;
            var rakiqTotalPrice = rakiqAmount * rakiqPrice;
            var wineTotalPrice = wineAmount * winePrice;
            var beerTotalPrice = beerAmount * beerPrice;

            var totalMoneyNeededToBuyEverything = whiskeyTotalPrice + rakiqTotalPrice + wineTotalPrice + beerTotalPrice;
            Console.WriteLine($"{totalMoneyNeededToBuyEverything:0.00}");
        }
    }
}
