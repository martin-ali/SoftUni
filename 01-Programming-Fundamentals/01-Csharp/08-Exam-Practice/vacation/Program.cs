using System;
using System.Collections.Generic;

namespace vacation
{
    // Forget about dictionaries for now - "Golden Hammer"
    class Program
    {
        enum Budget { Small, Medium, Large }

        enum Season { Summer, Winter }

        enum TypeOfStay { Camp, Hut, Hotel }

        private static Dictionary<Season, string> getLocation =
        new Dictionary<Season, string>
        {
            [Season.Summer] = "Alaska",
            [Season.Winter] = "Morocco"
        };

        private static Dictionary<Budget, string> getStay =
        new Dictionary<Budget, string>
        {
            [Budget.Small] = "Camp",
            [Budget.Medium] = "Hut",
            [Budget.Large] = "Hotel"
        };

        private static Dictionary<Budget, Dictionary<Season, decimal>> getPrice =
        new Dictionary<Budget, Dictionary<Season, decimal>>
        {
            [Budget.Small] = new Dictionary<Season, decimal>
            {
                [Season.Summer] = 0.65m,
                [Season.Winter] = 0.45m
            },
            [Budget.Medium] = new Dictionary<Season, decimal>
            {
                [Season.Summer] = 0.8m,
                [Season.Winter] = 0.6m
            },
            [Budget.Large] = new Dictionary<Season, decimal>
            {
                [Season.Summer] = 0.9m,
                [Season.Winter] = 0.9m
            }
        };

        static void Main()
        {
            decimal budgetSum = decimal.Parse(Console.ReadLine());
            string seasonText = Console.ReadLine().ToLower();

            var budget = ConvertBudgetNumberToBudgetType(budgetSum);
            var season = ConvertSeasonTextToSeason(seasonText);

            var price = budgetSum * getPrice[budget][season];
            var placeOfStay = getStay[budget];
            var location = getLocation[season];

            Console.WriteLine($"{location} - {placeOfStay} - {price:0.00}");
        }

        private static Season ConvertSeasonTextToSeason(string season)
        {
            if (season == "summer")
            {
                return Season.Summer;
            }
            else
            {
                return Season.Winter;
            }
        }

        private static Budget ConvertBudgetNumberToBudgetType(decimal budget)
        {
            if (0 <= budget && budget <= 1000)
            {
                return Budget.Small;
            }
            else if (1000 < budget && budget <= 3000)
            {
                return Budget.Medium;
            }
            else
            {
                return Budget.Large;
            }
        }
    }
}
