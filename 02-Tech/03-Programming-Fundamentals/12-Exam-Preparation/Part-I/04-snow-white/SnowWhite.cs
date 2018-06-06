using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_snow_white
{
    class SnowWhite
    {
        private static readonly string[] Separator = new string[] { " <:> " };

        static void Main()
        {
            var dwarfStatsById = new Dictionary<string, (string name, string color, int physics)>();
            var occurrencesByColor = new Dictionary<string, int>();
            var input = Console.ReadLine().Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "Once upon a time")
            {
                var name = input[0];
                var color = input[1];
                var physics = int.Parse(input[2]);
                var id = $"{name}{color}";

                var oldDwarfIsWeakerOrNonexistant = dwarfStatsById.ContainsKey(id) == false || dwarfStatsById[id].physics < physics;
                if (oldDwarfIsWeakerOrNonexistant)
                {
                    dwarfStatsById[id] = (name, color, physics);

                    if (occurrencesByColor.ContainsKey(color) == false)
                    {
                        occurrencesByColor[color] = 0;
                    }

                    occurrencesByColor[color]++;
                }

                input = Console.ReadLine().Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            }

            // This also passes zero test 2
            // var occurrencesByColor = dwarfStatsById.ToLookup(d => d.Value.color, d => d.Key);
            var orderedDwarfStatsById = dwarfStatsById.OrderByDescending(d => d.Value.physics).ThenByDescending(d => occurrencesByColor[d.Value.color]);
            foreach (var dwarfStats in orderedDwarfStatsById)
            {
                var dwarf = dwarfStats.Value;
                Console.WriteLine($"({dwarf.color}) {dwarf.name} <-> {dwarf.physics}");
            }
        }
    }
}
/*

Pesho <:> Red <:> 2000
Tosho <:> Blue <:> 1000
Gosho <:> Green <:> 1000
Sasho <:> Yellow <:> 4500
Prakasho <:> Stamat <:> 1000
Once upon a time

Pesho <:> Red <:> 5000
Pesho <:> Blue <:> 10000
Pesho <:> Red <:> 10000
Gosho <:> Blue <:> 10000
Once upon a time

 */
