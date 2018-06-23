using System;
using System.Collections.Generic;

namespace Small_Shop
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, double>> pricing = new Dictionary<string, Dictionary<string, double>>()
            {
                ["sofia"] = new Dictionary<string, double>
                {
                    ["coffee"] = 0.5,
                    ["water"] = 0.8,
                    ["beer"] = 1.2,
                    ["sweets"] = 1.45,
                    ["peanuts"] = 1.6
                },

                ["plovdiv"] = new Dictionary<string, double>
                {
                    ["coffee"] = 0.4,
                    ["water"] = 0.7,
                    ["beer"] = 1.15,
                    ["sweets"] = 1.3,
                    ["peanuts"] = 1.5
                },

                ["varna"] = new Dictionary<string, double>
                {
                    ["coffee"] = 0.45,
                    ["water"] = 0.7,
                    ["beer"] = 1.1,
                    ["sweets"] = 1.35,
                    ["peanuts"] = 1.55
                }
            };

            var product = Console.ReadLine();
            var city = Console.ReadLine();
            var quantity = double.Parse(Console.ReadLine());

            var totalPrice = pricing[city.ToLower()][product.ToLower()] * quantity;
            Console.WriteLine(totalPrice);
        }
    }
}
