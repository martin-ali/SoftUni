using System;

namespace shopping
{
    class Program
    {
        static void Main()
        {
            // decimal budget = 10;
            // int chocolateNumber = 5;
            // decimal milkQuantity = 1.5m;

            decimal budget = decimal.Parse(Console.ReadLine());
            int chocolateNumber = int.Parse(Console.ReadLine());
            decimal milkQuantity = decimal.Parse(Console.ReadLine());
            decimal mandarineNumber = (decimal)Math.Floor(chocolateNumber * 0.65);

            decimal chocolatePrice = 0.65m;
            decimal milkPrice = 2.7m;
            decimal mandarinePrice = 0.20m;

            var moneyRequired = (chocolateNumber * chocolatePrice) + (milkQuantity * milkPrice) + (mandarineNumber * mandarinePrice);
            if (budget >= moneyRequired)
            {
                Console.WriteLine($"You got this, {budget - moneyRequired:0.00} money left!");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {moneyRequired - budget:0.00} more!");
            }
        }
    }
}
