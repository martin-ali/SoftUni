using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_inferno_iii
{
    class InfernoIII
    {
        static void Main()
        {
            var gems = Console.ReadLine().Split().Select(int.Parse).ToList();
            var excluded = new bool[gems.Count];

            var filterById = new Dictionary<string, Func<List<int>, int, bool>>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Forge")
            {
                var parameters = input.Split(';');
                var command = parameters[0];
                var condition = parameters[1];
                var argument = int.Parse(parameters[2]);
                var id = $"{condition}-{argument}";

                if (command == "Reverse")
                {
                    filterById.Remove(id);
                    continue;
                }

                filterById[id] = (items, index) =>
                {
                    var item = items[index];

                    if (condition.Contains("Left")
                    && IsInRange(items, index - 1))
                    {
                        item += items[index - 1];
                    }

                    if (condition.Contains("Right")
                    && IsInRange(items, index + 1))
                    {
                        item += items[index + 1];
                    }

                    return item == argument;
                };
            }

            for (int index = 0; index < gems.Count; index++)
            {
                excluded[index] = filterById.Any(filter => filter.Value(gems, index));
            }

            var filteredGems = gems.Where((gem, index) => excluded[index] == false);

            Console.WriteLine(string.Join(' ', filteredGems));
        }

        private static bool IsInRange<G>(List<G> items, int index)
        {
            return 0 <= index && index < items.Count;
        }
    }
}
