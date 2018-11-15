using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_hit_list
{
    class HitList
    {
        static void Main()
        {
            var infoByPerson = new Dictionary<string, SortedDictionary<string, string>>();

            var targetInfoIndex = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            while (input != "end transmissions")
            {
                var data = input.Split(new[] { '=', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                var person = data[0];

                if (infoByPerson.ContainsKey(person) == false)
                {
                    infoByPerson[person] = new SortedDictionary<string, string>();
                }

                for (int i = 1; i < data.Length; i += 2)
                {
                    var key = data[i];
                    var value = data[i + 1];
                    infoByPerson[person][key] = value;
                }

                input = Console.ReadLine();
            }

            var personToKill = Console.ReadLine().Replace("Kill ", "");

            Console.WriteLine($"Info on {personToKill}:");
            foreach (var detail in infoByPerson[personToKill])
            {
                Console.WriteLine($"---{detail.Key}: {detail.Value}");
            }

            var infoIndex = infoByPerson[personToKill].Sum(i => i.Key.Length + i.Value.Length);
            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine($"Proceed");
            }
            else
            {
                var infoNeeded = targetInfoIndex - infoIndex;
                Console.WriteLine($"Need {infoNeeded} more info.");
            }
        }
    }
}
