using System;

namespace Journey
{
    class Program
    {
        static void Main()
        {
            var budget = decimal.Parse(Console.ReadLine());
            var season = Console.ReadLine().ToLower();
            string place;
            decimal moneySpent = 0;
            string holidayType = "";

            if (budget > 1000)
            {
                place = "Europe";
                holidayType = "Hotel";
                moneySpent = budget * 0.9m;
            }
            else if (budget > 100)
            {
                place = "Balkans";
                if (season == "summer")
                {
                    holidayType = "Camp";
                    moneySpent = budget * 0.4m;
                }
                else
                {
                    holidayType = "Hotel";
                    moneySpent = budget * 0.8m;
                }
            }
            else
            {
                place = "Bulgaria";
                if (season == "summer")
                {
                    holidayType = "Camp";
                    moneySpent = budget * 0.3m;
                }
                else
                {
                    holidayType = "Hotel";
                    moneySpent = budget * 0.7m;
                }
            }

            Console.WriteLine($"Somewhere in {place}");
            Console.WriteLine($"{holidayType} - {moneySpent:0.00}");

        }
    }
}
