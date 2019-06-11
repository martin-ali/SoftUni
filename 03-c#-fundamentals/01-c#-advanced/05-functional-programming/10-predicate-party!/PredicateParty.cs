using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_predicate_party_
{
    class PredicateParty
    {
        static void Main()
        {
            var names = Console.ReadLine().Split().ToList();

            var input = Console.ReadLine();
            while (input != "Party!")
            {
                var parameters = input.Split();
                var command = parameters[0];
                var condition = parameters[1];
                var argument = parameters[2];

                Func<string, bool> filter;
                if (condition == "StartsWith")
                {
                    filter = (string name) => name.StartsWith(argument);
                }
                else if (condition == "EndsWith")
                {
                    filter = (string name) => name.EndsWith(argument);
                }
                else //if (condition == "Length")
                {
                    filter = (string name) => name.Length == int.Parse(argument);
                }

                var newNames = new List<string>();
                if (command == "Remove")
                {
                    foreach (var name in names)
                    {
                        if (filter(name) == false)
                        {
                            newNames.Add(name);
                        }
                    }
                }
                else if (command == "Double")
                {
                    foreach (var name in names)
                    {
                        newNames.Add(name);
                        if (filter(name))
                        {
                            newNames.Add(name);
                        }
                    }
                }

                names = newNames;
                input = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                var peopleGoingToParty = string.Join(", ", names);
                Console.WriteLine($"{peopleGoingToParty} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
        }
    }
}
