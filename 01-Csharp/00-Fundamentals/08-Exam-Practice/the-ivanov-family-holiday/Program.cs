using System;
using System.Collections.Generic;

namespace the_ivanov_family_holiday
{
    class Program
    {
        enum StayLength { Short, Medium, Long };

        enum Age { Adult, Child };

        private static Dictionary<string, Dictionary<StayLength, Dictionary<Age, decimal>>> destinationPricing
        = new Dictionary<string, Dictionary<StayLength, Dictionary<Age, decimal>>>()
        {
            ["miami"] = new Dictionary<StayLength, Dictionary<Age, decimal>>()
            {
                [StayLength.Short] = new Dictionary<Age, decimal>()
                {
                    [Age.Adult] = 24.99m,
                    [Age.Child] = 14.99m
                },
                [StayLength.Medium] = new Dictionary<Age, decimal>()
                {
                    [Age.Adult] = 22.99m,
                    [Age.Child] = 11.99m
                },
                [StayLength.Long] = new Dictionary<Age, decimal>()
                {
                    [Age.Adult] = 20m,
                    [Age.Child] = 10m
                }
            },
            ["canary islands"] = new Dictionary<StayLength, Dictionary<Age, decimal>>()
            {
                [StayLength.Short] = new Dictionary<Age, decimal>()
                {
                    [Age.Adult] = 32.50m,
                    [Age.Child] = 28.50m
                },
                [StayLength.Medium] = new Dictionary<Age, decimal>()
                {
                    [Age.Adult] = 30.50m,
                    [Age.Child] = 25.60m
                },
                [StayLength.Long] = new Dictionary<Age, decimal>()
                {
                    [Age.Adult] = 28m,
                    [Age.Child] = 22m
                }
            },
            ["philippines"] = new Dictionary<StayLength, Dictionary<Age, decimal>>()
            {
                [StayLength.Short] = new Dictionary<Age, decimal>()
                {
                    [Age.Adult] = 42.99m,
                    [Age.Child] = 39.99m
                },
                [StayLength.Medium] = new Dictionary<Age, decimal>()
                {
                    [Age.Adult] = 41m,
                    [Age.Child] = 36m
                },
                [StayLength.Long] = new Dictionary<Age, decimal>()
                {
                    [Age.Adult] = 38.50m,
                    [Age.Child] = 32.40m
                }
            }
        };

        private static Dictionary<string, Dictionary<Age, decimal>> transportationPricing
        = new Dictionary<string, Dictionary<Age, decimal>>()
        {
            ["train"] = new Dictionary<Age, decimal>()
            {
                [Age.Adult] = 22.3m,
                [Age.Child] = 12.5m
            },
            ["bus"] = new Dictionary<Age, decimal>()
            {
                [Age.Adult] = 45m,
                [Age.Child] = 37m
            },
            ["airplane"] = new Dictionary<Age, decimal>()
            {
                [Age.Adult] = 90m,
                [Age.Child] = 68.50m
            },
        };

        static void Main()
        {
            int numberOfNights = int.Parse(Console.ReadLine());
            string destination = Console.ReadLine().ToLower();
            string transport = Console.ReadLine().ToLower();

            StayLength stayLength = ConvertNumberOfNightsToStayLength(numberOfNights);

            decimal transportationCost =
            (transportationPricing[transport][Age.Child] * 3)
            + (transportationPricing[transport][Age.Adult] * 2);

            decimal stayCost = numberOfNights *
            ((destinationPricing[destination][stayLength][Age.Child] * 3) + (destinationPricing[destination][stayLength][Age.Adult] * 2))
            * 1.25m;

            decimal expense = transportationCost + stayCost;

            Console.WriteLine($"{expense:0.000}");
        }

        private static StayLength ConvertNumberOfNightsToStayLength(int numberOfNights)
        {
            if (numberOfNights <= 10)
            {
                return StayLength.Short;
            }
            else if (11 <= numberOfNights && numberOfNights <= 15)
            {
                return StayLength.Medium;
            }
            else
            {
                return StayLength.Long;
            }
        }
    }
}
