using System;

namespace _04_hotel
{
    class Hotel
    {
        static void Main()
        {
            var month = Console.ReadLine().ToLower();
            byte numberOfNights = byte.Parse(Console.ReadLine());

            var prices = (studio: 0m, doubleRoom: 0m, masterSuite: 0m);
            var totalCost = (studio: 0m, doubleRoom: 0m, masterSuite: 0m);

            switch (month)
            {
                case "may":
                case "october":
                    prices = (studio: 50m, doubleRoom: 65m, masterSuite: 75m);
                    break;
                case "june":
                case "september":
                    prices = (studio: 60m, doubleRoom: 72m, masterSuite: 82m);
                    break;
                case "july":
                case "august":
                case "december":
                    prices = (studio: 68m, doubleRoom: 77m, masterSuite: 89m);
                    break;
            }

            totalCost =
            (
                studio: numberOfNights * prices.studio,
                doubleRoom: numberOfNights * prices.doubleRoom,
                masterSuite: numberOfNights * prices.masterSuite
            );

            if (numberOfNights > 14)
            {
                switch (month)
                {

                    case "july":
                    case "august":
                    case "december":
                        totalCost.masterSuite *= 0.85m;
                        break;
                    case "june":
                    case "september":
                        totalCost.doubleRoom *= 0.9m;
                        break;
                }
            }
            else if (numberOfNights > 7)
            {
                if (month == "october" || month == "september")
                {
                    totalCost.studio -= prices.studio;
                }

                if (month == "october" || month == "may")
                {
                    totalCost.studio *= 0.95m;
                }
            }

            Console.WriteLine($"Studio: {totalCost.studio:0.00} lv.");
            Console.WriteLine($"Double: {totalCost.doubleRoom:0.00} lv.");
            Console.WriteLine($"Suite: {totalCost.masterSuite:0.00} lv.");
        }
    }
}
