using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _10_predicate_party_
{
    class PredicateParty
    {
        // Passes 100/100 even when appending the doubled names to the end of the list
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
#endif

            var names = Console.ReadLine().Split().ToList();

            var commandRaw = Console.ReadLine();
            while (commandRaw != "Party!")
            {
                var commandData = commandRaw.Split();
                var command = commandData[0];
                var filterType = commandData[1];
                var parameter = commandData[2];

                var filter = GetFilter(filterType, parameter);
                names = Execute(command, names, filter);

                commandRaw = Console.ReadLine();
            }

            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                string invitedNames = string.Join(", ", names);
                Console.WriteLine($"{invitedNames} are going to the party!");
            }
        }

        private static Predicate<string> GetFilter(string filter, string parameter)
        {
            if (filter == "StartsWith")
            {
                return word => word.StartsWith(parameter);
            }
            else if (filter == "EndsWith")
            {
                return word => word.EndsWith(parameter);
            }
            else if (filter == "Length")
            {
                return word => word.Length == int.Parse(parameter);
            }

            return null;
        }

        private static List<string> Execute(string command, List<string> names, Predicate<string> criteria)
        {
            if (command == "Double")
            {
                var doubledNames = new List<string>();
                for (int i = 0; i < names.Count; i++)
                {
                    doubledNames.Add(names[i]);
                    if (criteria(names[i]))
                    {
                        doubledNames.Add(names[i]);
                    }
                }

                return doubledNames;
            }
            else if (command == "Remove")
            {
                names.RemoveAll(criteria);
            }

            return names;
        }
    }
}
