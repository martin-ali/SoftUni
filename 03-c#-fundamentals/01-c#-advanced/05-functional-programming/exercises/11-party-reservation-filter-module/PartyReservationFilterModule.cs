using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _11_party_reservation_filter_module
{
    class PartyReservationFilterModule
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test2.txt"));
#endif

            var names = Console.ReadLine().Split().ToList();
            var filters = new Dictionary<string, Predicate<string>>();

            var commandRaw = Console.ReadLine();
            while (commandRaw != "Print")
            {
                var commandData = commandRaw.Split(';');
                var command = commandData[0];
                var filterType = commandData[1];
                var parameter = commandData[2];

                var filterId = $"{filterType}-{parameter}";
                if (command == "Add filter")
                {
                    filters[filterId] = GetFilter(filterType, parameter);
                }
                else if (command == "Remove filter")
                {
                    filters.Remove(filterId);
                }

                commandRaw = Console.ReadLine();
            }

            names.RemoveAll(name => filters.Any(fulfilsCriteria => fulfilsCriteria.Value(name)));
            Console.WriteLine(string.Join(" ", names));
        }

        private static Predicate<string> GetFilter(string filter, string parameter)
        {
            if (filter == "Starts with")
            {
                return word => word.StartsWith(parameter);
            }
            else if (filter == "Ends with")
            {
                return word => word.EndsWith(parameter);
            }
            else if (filter == "Length")
            {
                return word => word.Length == int.Parse(parameter);
            }
            else if (filter == "Contains")
            {
                return word => word.Contains(parameter);
            }

            return null;
        }
    }
}
