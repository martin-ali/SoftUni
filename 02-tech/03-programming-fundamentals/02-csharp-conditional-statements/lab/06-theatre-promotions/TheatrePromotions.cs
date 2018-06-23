using System;
using System.Collections.Generic;

namespace _06_theatre_promotions
{
    class TheatrePromotions
    {
        static void Main()
        {
            var youngPeoplePricing = new Dictionary<string, decimal>
            {
                ["weekday"] = 12,
                ["weekend"] = 15,
                ["holiday"] = 5,
            };
            var middleAgedPeoplePricing = new Dictionary<string, decimal>
            {
                ["weekday"] = 18,
                ["weekend"] = 20,
                ["holiday"] = 12,
            };
            var elderlyPeoplePricing = new Dictionary<string, decimal>
            {
                ["weekday"] = 12,
                ["weekend"] = 15,
                ["holiday"] = 10,
            };

            var day = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            string result = "Error!";

            if (0 <= age && age <= 18)
            {
                result = youngPeoplePricing[day] + "$";
            }
            else if (18 < age && age <= 64)
            {
                result = middleAgedPeoplePricing[day] + "$";
            }
            else if (64 < age && age <= 122)
            {
                result = elderlyPeoplePricing[day] + "$";
            }

            Console.WriteLine(result);
        }
    }
}
