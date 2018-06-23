using System;

namespace Charity_Campaign
{
    class Program
    {
        static void Main()
        {
            //var campaignLength = 20;
            //var numberOfBakers = 8;
            //var numberOfCakes = 14;
            //var numberOfGofreti = 30;
            //var numberOfPancakes = 16;

            var campaignLength = uint.Parse(Console.ReadLine());
            var numberOfBakers = uint.Parse(Console.ReadLine());
            var numberOfCakes = uint.Parse(Console.ReadLine());
            var numberOfGofreti = uint.Parse(Console.ReadLine());
            var numberOfPancakes = uint.Parse(Console.ReadLine());

            var cakeMoney = campaignLength * numberOfBakers * numberOfCakes * 45m;
            var gofetiMoney = campaignLength * numberOfBakers * numberOfGofreti * 5.8m;
            var pancakeMoney = campaignLength * numberOfBakers * numberOfPancakes * 3.2m;

            var moneyGathered = cakeMoney + gofetiMoney + pancakeMoney;

            decimal result = moneyGathered - (moneyGathered / 8);
            Console.WriteLine($"{result:0.00}");
        }
    }
}
