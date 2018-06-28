using System;
using System.Collections.Generic;

namespace _03_restaurant_discount
{
    class RestaurantDiscount
    {
        private static Dictionary<string, decimal> hallPrices = new Dictionary<string, decimal>
        {
            ["Small Hall"] = 2500,
            ["Terrace"] = 5000,
            ["Great Hall"] = 7500
        };

        private static Dictionary<string, decimal> discounts = new Dictionary<string, decimal>
        {
            ["Normal"] = 0.95m,
            ["Gold"] = 0.90m,
            ["Platinum"] = 0.85m
        };

        private static Dictionary<string, decimal> packagePrices = new Dictionary<string, decimal>
        {
            ["Normal"] = 500,
            ["Gold"] = 750,
            ["Platinum"] = 1000
        };

        static void Main()
        {
            int groupSize = int.Parse(Console.ReadLine());
            var package = Console.ReadLine();
            var hall = string.Empty;
            decimal totalPrice = 0;

            if (groupSize > 120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            if (0 <= groupSize && groupSize <= 50)
            {
                hall = "Small Hall";
            }
            else if (50 < groupSize && groupSize <= 100)
            {
                hall = "Terrace";
            }
            else
            {
                hall = "Great Hall";
            }

            totalPrice = ((packagePrices[package] + hallPrices[hall]) * discounts[package]);
            decimal pricePerPerson = totalPrice / groupSize;
            Console.WriteLine($"We can offer you the {hall}");
            Console.WriteLine($"The price per person is {pricePerPerson:0.00}$");
        }
    }
}