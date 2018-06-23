using System;
using System.Collections.Generic;

namespace _08_calories_counter
{
    class CaloriesCounter
    {
        static void Main()
        {
            var calories = new Dictionary<string, int>
            {
                ["cheese"] = 500,
                ["tomato sauce"] = 150,
                ["salami"] = 600,
                ["pepper"] = 50
            };

            int n = int.Parse(Console.ReadLine());
            int totalCalories = 0;
            for (int i = 0; i < n; i++)
            {
                var ingredient = Console.ReadLine().ToLower();
                if (calories.ContainsKey(ingredient))
                {
                    totalCalories += calories[ingredient];
                }
            }

            Console.WriteLine($"Total calories: {totalCalories}");
        }
    }
}
