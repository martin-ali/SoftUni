using System;
using System.Collections.Generic;

namespace match_tickets
{
    class Program
    {
        enum CategoryType { Vip, Normal};

        static void Main()
        {
            // Why do it this way? Need to recall syntax
            var budget = decimal.Parse(Console.ReadLine());
            var category = (CategoryType)Enum.Parse(typeof(CategoryType), Console.ReadLine(), true);
            var numberOfPeople = int.Parse(Console.ReadLine());
            var ticketPricing = new Dictionary<CategoryType, decimal>()
            {
                [CategoryType.Vip] = 499.99m,
                [CategoryType.Normal] = 249.99m
            };

            var budgetLeftAfterTransport = GetMoneyAfterTransport(numberOfPeople, budget);
            var moneyNeededForTickets = ticketPricing[category] * numberOfPeople;
            var result = budgetLeftAfterTransport - moneyNeededForTickets;

            if (result >= 0)
            {
                Console.WriteLine($"Yes! You have {result:0.00} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {-result:0.00} leva.");
            }
        }

        static decimal GetMoneyAfterTransport(int numberOfParticipants, decimal budget)
        {
            decimal budgetLeft = 0;

            if (1 >= numberOfParticipants || numberOfParticipants <= 4)
            {
                // 75% for transport
                budgetLeft = budget/4;
            }
            else if (5 >= numberOfParticipants || numberOfParticipants <= 9)
            {
                // 60% for transport
                budgetLeft = budget * 0.4m;
            }
            else if (10 >= numberOfParticipants || numberOfParticipants <= 24)
            {
                // 50% for transport
                budgetLeft = budget/2;
            }
            else if (25 >= numberOfParticipants || numberOfParticipants <= 49)
            {
                // 40% for transport
                budgetLeft = budget * 0.6m;
            }
            else
            {
                // 25% for transport
                budgetLeft = budget * 0.75m;
            }            

            return budgetLeft;
        }
    }
}
