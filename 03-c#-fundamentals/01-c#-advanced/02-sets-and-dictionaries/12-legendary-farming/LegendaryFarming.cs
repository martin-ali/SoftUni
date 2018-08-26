using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_legendary_farming
{
    class LegendaryFarming
    {
        static void Main()
        {
            var junkMaterials = new SortedDictionary<string, int>();
            var legendaryMaterials = new SortedDictionary<string, int>()
            {
                ["fragments"] = 0,
                ["shards"] = 0,
                ["motes"] = 0
            };
            var legendaryByMaterial = new Dictionary<string, string>()
            {
                ["fragments"] = "Valanyr",
                ["shards"] = "Shadowmourne",
                ["motes"] = "Dragonwrath"
            };

            while (true)
            {
                var materials = Console.ReadLine().Split();

                for (int i = 0; i < materials.Length; i += 2)
                {
                    var quantity = int.Parse(materials[i]);
                    var material = materials[i + 1].ToLower();

                    if (legendaryMaterials.ContainsKey(material))
                    {
                        legendaryMaterials[material] += quantity;

                        if (legendaryMaterials[material] >= 250)
                        {
                            Console.WriteLine($"{legendaryByMaterial[material]} obtained!");
                            legendaryMaterials[material] -= 250;
                            goto printResults;
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

        printResults:
            foreach (var legendaryMaterial in legendaryMaterials.OrderByDescending(lm => lm.Value))
            {
                Console.WriteLine($"{legendaryMaterial.Key}: {legendaryMaterial.Value}");
            }

            foreach (var junkMaterial in junkMaterials)
            {
                Console.WriteLine($"{junkMaterial.Key}: {junkMaterial.Value}");
            }
        }
    }
}
/*

3 Motes 5 stones 5 Shards
6 leathers 255 fragments 7 shards

123 silver 6 shards 8 shards 5 motes
9 fangs 75 motes 103 MOTES 8 Shards
86 Motes 7 stones 19 silver

*/
