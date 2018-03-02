using System;
using System.Collections.Generic;

namespace the_ivanov_family_holiday
{
    class Program
    {
        delegate decimal Del(string str);

        enum StayLength { Short, Medium, Long };

        static void Main()
        {
            var destinationMap = new Dictionary<string, Dictionary<StayLength, Dictionary<string, decimal>>>()
            {
                ["miami"] = new Dictionary<StayLength, Dictionary<string, decimal>>()
                {
                    [StayLength.Short] = new Dictionary<string, decimal>()
                    {
                        ["oldfart"] = 24.99m,
                        ["child"] = 14.99m
                    },
                    [StayLength.Medium] = new Dictionary<string, decimal>()
                    {
                        ["oldfart"] = 22.99m,
                        ["child"] = 11.99m
                    },
                    [StayLength.Long] = new Dictionary<string, decimal>()
                    {
                        ["oldfart"] = 20m,
                        ["child"] = 10m
                    }
                },
                ["canary islands"] = new Dictionary<StayLength, Dictionary<string, decimal>>()
                {
                    [StayLength.Short] = new Dictionary<string, decimal>()
                    {
                        ["oldfart"] = 32.50m,
                        ["child"] = 28.50m
                    },
                    [StayLength.Medium] = new Dictionary<string, decimal>()
                    {
                        ["oldfart"] = 30.50m,
                        ["child"] = 25.60m
                    },
                    [StayLength.Long] = new Dictionary<string, decimal>()
                    {
                        ["oldfart"] = 28m,
                        ["child"] = 22m
                    }
                },
                ["philippines"] = new Dictionary<StayLength, Dictionary<string, decimal>>()
                {
                    [StayLength.Short] = new Dictionary<string, decimal>()
                    {
                        ["oldfart"] = 42.99m,
                        ["child"] = 39.99m
                    },
                    [StayLength.Medium] = new Dictionary<string, decimal>()
                    {
                        ["oldfart"] = 41m,
                        ["child"] = 36m
                    },
                    [StayLength.Long] = new Dictionary<string, decimal>()
                    {
                        ["oldfart"] = 38.50m,
                        ["child"] = 32.40m
                    }
                }
            };

            var transportationMap = new Dictionary<string, Dictionary<string, decimal>>()
            {
                ["train"] = new Dictionary<string, decimal>()
                {
                    ["oldfart"] = 22.3m,
                    ["child"] = 12.5m
                },
                ["bus"] = new Dictionary<string, decimal>()
                {
                    ["oldfart"] = 45m,
                    ["child"] = 37m
                },
                ["airplane"] = new Dictionary<string, decimal>()
                {
                    ["oldfart"] = 90m,
                    ["child"] = 68.50m
                },
            };

            int numberOfNights = int.Parse(Console.ReadLine());
            string destination = Console.ReadLine().ToLower();
            string transport = Console.ReadLine().ToLower();

            StayLength stay = ConvertNumberOfNightsToStayLength(numberOfNights);

            decimal transportationCost =
            (transportationMap[transport]["child"] * 3)
            + (transportationMap[transport]["oldfart"] * 2);

            decimal stayCost = numberOfNights *
            ((destinationMap[destination][stay]["child"] * 3) + (destinationMap[destination][stay]["oldfart"] * 2))
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
