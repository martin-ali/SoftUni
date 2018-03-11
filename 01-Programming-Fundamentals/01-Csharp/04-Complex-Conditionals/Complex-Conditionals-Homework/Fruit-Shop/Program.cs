using System;
using System.Collections.Generic;

namespace Fruit_Shop
{
    class Program
    {
        static void Main()
        {
            var validDaysOfWeek = new HashSet<string> {
                { "monday" },
                { "tuesday" },
                { "wednesday" },
                { "thursday" },
                { "friday" },
                { "saturday" },
                { "sunday"}
            };

            var validFruits = new HashSet<string> {
                { "banana" },
                { "apple" },
                { "orange" },
                { "grapefruit" },
                { "kiwi" },
                { "pineapple" },
                { "grapes"}
            };

            var weekdayPricing = new Dictionary<string, double>
            {
                ["banana"] = 2.5,
                ["apple"] = 1.2,
                ["orange"] = 0.85,
                ["grapefruit"] = 1.45,
                ["kiwi"] = 2.7,
                ["pineapple"] = 5.5,
                ["grapes"] = 3.85
            };

            var weekendPricing = new Dictionary<string, double>
            {
                ["banana"] = 2.7,
                ["apple"] = 1.25,
                ["orange"] = 0.9,
                ["grapefruit"] = 1.6,
                ["kiwi"] = 3,
                ["pineapple"] = 5.6,
                ["grapes"] = 4.2
            };

            Dictionary<string, Dictionary<string, double>> pricing = new Dictionary<string, Dictionary<string, double>>()
            {
                ["monday"] = weekdayPricing,
                ["tuesday"] = weekdayPricing,
                ["wednesday"] = weekdayPricing,
                ["thursday"] = weekdayPricing,
                ["friday"] = weekdayPricing,
                ["saturday"] = weekendPricing,
                ["sunday"] = weekendPricing
            };

            var fruit = Console.ReadLine();
            var dayOfTheWeek = Console.ReadLine();
            var quantity = double.Parse(Console.ReadLine());

            if (validDaysOfWeek.Contains(dayOfTheWeek.ToLower()) && validFruits.Contains(fruit.ToLower()))
            {
                var totalPrice = pricing[dayOfTheWeek.ToLower()][fruit.ToLower()] * quantity;
                Console.WriteLine($"{totalPrice:0.00}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
