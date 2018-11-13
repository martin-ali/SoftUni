using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _12_inferno_iii
{
    class InfernoIII
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
#endif

            var gems = Console.ReadLine().Split().Select(int.Parse).ToList();
            var eliminated = new bool[gems.Count];
            var filterById = new Dictionary<string, Func<List<int>, bool[], bool[]>>();

            var input = Console.ReadLine();
            while (input != "Forge")
            {
                var commandData = input.Split(';');
                var command = commandData[0];
                var criteria = commandData[1];
                var value = int.Parse(commandData[2]);

                var filterId = $"{criteria}{value}";

                if (command == "Exclude")
                {
                    var shouldSumLeft = criteria.Contains("Left");
                    var shouldSumRight = criteria.Contains("Right");

                    filterById[filterId] = GetFilter(value, shouldSumLeft, shouldSumRight);
                }
                else if (command == "Reverse")
                {
                    filterById.Remove(filterId);
                }

                input = Console.ReadLine();
            }

            foreach (var filter in filterById)
            {
                eliminated = filter.Value(gems, eliminated);
            }

            var filteredGems = gems.Where((gem, index) => eliminated[index] == false);
            Console.WriteLine(string.Join(' ', filteredGems));
        }

        private static Func<List<int>, bool[], bool[]> GetFilter(int value, bool shouldSumLeft, bool shouldSumRight)
        {
            return (List<int> gems, bool[] eliminated) =>
            {
                return eliminated.Select((isGemEliminated, index) =>
                {
                    var gem = gems[index];

                    if (shouldSumLeft)
                    {
                        gem += 0 <= (index - 1) ? gems[index - 1] : 0;
                    }
                    if (shouldSumRight)
                    {
                        gem += (index + 1) < gems.Count ? gems[index + 1] : 0;
                    }

                    if (gem == value)
                    {
                        return true;
                    }

                    return isGemEliminated;
                })
                .ToArray();
            };
        }
    }
}
