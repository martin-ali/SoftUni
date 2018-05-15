using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _09_legendary_farming
{
    class LegendaryFarming
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
            #endif


            var junkMaterials = new SortedDictionary<string, int>();
            var keyMaterials = new SortedDictionary<string, int>
            {
                ["fragments"] = 0,
                ["shards"] = 0,
                ["motes"] = 0
            };
            var legendaryByMaterial = new Dictionary<string, string>
            {
                ["fragments"] = "Valanyr",
                ["shards"] = "Shadowmourne",
                ["motes"] = "Dragonwrath"
            };

            while (true)
            {
                var parameters = Console.ReadLine().Split(' ');
                for (int i = 0; i < parameters.Length; i += 2)
                {
                    var quantity = int.Parse(parameters[i]);
                    var material = parameters[i + 1].ToLower();

                    if (keyMaterials.ContainsKey(material))
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            Console.WriteLine($"{legendaryByMaterial[material]} obtained!");
                            keyMaterials[material] -= 250;
                            goto displayResults;
                        }

                        continue;
                    }

                    if (junkMaterials.ContainsKey(material) == false)
                    {
                        junkMaterials[material] = 0;
                    }

                    junkMaterials[material] += quantity;
                }

            }

        displayResults:
            // .ThenBy(mat => mat.Key)
            var sortedKeyMaterials = keyMaterials.OrderByDescending(mat => mat.Value);
            foreach (var keyMaterial in sortedKeyMaterials)
            {
                Console.WriteLine($"{keyMaterial.Key}: {keyMaterial.Value}");
            }

            foreach (var junk in junkMaterials)
            {
                Console.WriteLine($"{junk.Key}: {junk.Value}");
            }
        }
    }
}
