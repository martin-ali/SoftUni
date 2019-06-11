using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_party_reservation_filter_module
{
    class PartyReservationFilterModule
    {
        static void Main()
        {
            var names = Console.ReadLine().Split().ToList();

            var filters = new Dictionary<string, Func<string, bool>>();
            var input = Console.ReadLine();
            while (input != "Print")
            {
                var parameters = input.Split(';');
                var command = parameters[0];
                var condition = parameters[1];
                var argument = parameters[2];
                var id = $"{condition}-{argument}";

                if (command == "Add filter")
                {
                    if (condition == "Starts with")
                    {
                        filters[id] = (name) => name.StartsWith(argument);
                    }
                    else if (condition == "Ends with")
                    {
                        filters[id] = (name) => name.EndsWith(argument);
                    }
                    else if (condition == "Length")
                    {
                        filters[id] = (name) => name.Length == int.Parse(argument);
                    }
                    else //if (condition == "Contains")
                    {
                        filters[id] = (name) => name.Contains(argument);
                    }
                }
                else if (command == "Remove filter")
                {
                    filters.Remove(id);
                }

                input = Console.ReadLine();
            }

            names.RemoveAll(name => filters.Values.Any(filter => filter(name)));

            Console.WriteLine(string.Join(' ', names));
        }
    }
}
