using System;
using System.Collections.Generic;

namespace dream_item
{
    class Program
    {
        // Simple. Could use the DateTime class, but that would complicate things
        private static Dictionary<string, int> monthLengths = new Dictionary<string, int>()
        {
            ["Jan"] = 31,
            ["Feb"] = 28,
            ["March"] = 31,
            ["Apr"] = 30,
            ["May"] = 31,
            ["June"] = 30,
            ["July"] = 31,
            ["Aug"] = 31,
            ["Sept"] = 30,
            ["Oct"] = 31,
            ["Nov"] = 30,
            ["Dec"] = 31
        };

        static void Main()
        {
            // Input
            string[] data = Console.ReadLine().Split('\\');
            // string[] data = @"Sept\4.39\8\772.64".Split('\\');

            string month = data[0];
            decimal moneyPerHour = decimal.Parse(data[1]);
            int hoursPerDay = int.Parse(data[2]);
            decimal priceOfDreamItem = decimal.Parse(data[3]);

            bool moneyIsEnough = false;

            // Logic
            int workdays = monthLengths[month] - 10;
            decimal moneyMade = workdays * hoursPerDay * moneyPerHour;

            if (moneyMade > 700) moneyMade *= 1.1m;
            if (moneyMade >= priceOfDreamItem) moneyIsEnough = true;
            decimal result = Math.Abs(priceOfDreamItem - moneyMade);

            // Output
            if (moneyIsEnough)
            {
                Console.WriteLine($"Money left = {result:0.00} leva.");
            }
            else
            {
                Console.WriteLine($"Not enough money. {result:0.00} leva needed.");
            }
        }
    }
}
