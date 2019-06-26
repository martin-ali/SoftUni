using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_spaceship_crafting
{
    class SpaceshipCrafting
    {
        private const string Aluminium = "Aluminium";
        private const string Glass = "Glass";
        private const string Lithium = "Lithium";
        private const string CarbonFiber = "Carbon fiber";

        static void Main()
        {
            var materialByValue = new Dictionary<int, string>()
            {
                [25] = Glass,
                [50] = Aluminium,
                [75] = Lithium,
                [100] = CarbonFiber
            };

            var materialsCountByName = new Dictionary<string, int>()
            {
                [Aluminium] = 0,
                [CarbonFiber] = 0,
                [Glass] = 0,
                [Lithium] = 0
            };

            var chemicalLiquids = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).Reverse());
            var physicalItems = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            while (chemicalLiquids.Any() && physicalItems.Any())
            {
                var liquid = chemicalLiquids.Pop();
                var item = physicalItems.Pop();

                var sum = liquid + item;

                if (materialByValue.ContainsKey(sum))
                {
                    var material = materialByValue[sum];

                    materialsCountByName[material]++;
                    continue;
                }
                else
                {
                    physicalItems.Push(item + 3);
                }
            }

            var allMaterialsHaveBeenCreated = materialsCountByName.All(m => m.Value > 0);
            if (allMaterialsHaveBeenCreated)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            var liquidsLeft = chemicalLiquids.Any()
                                ? string.Join(", ", chemicalLiquids)
                                : "none";
            Console.WriteLine($"Liquids left: {liquidsLeft}");

            var itemsLeft = physicalItems.Any()
                                ? string.Join(", ", physicalItems)
                                : "none";
            Console.WriteLine($"Physical items left: {itemsLeft}");

            var materials = new[] { Aluminium, CarbonFiber, Glass, Lithium };
            foreach (var material in materials)
            {
                Console.WriteLine($"{material}: {materialsCountByName[material]}");
            }
        }
    }
}
