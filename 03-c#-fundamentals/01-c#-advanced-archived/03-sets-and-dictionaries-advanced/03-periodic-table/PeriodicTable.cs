using System;
using System.Collections.Generic;

namespace _03_periodic_table
{
    class PeriodicTable
    {
        static void Main()
        {
            var compoundCount = int.Parse(Console.ReadLine());

            var uniqueChemicalElements = new SortedSet<string>();
            for (int i = 0; i < compoundCount; i++)
            {
                var compoundChemicalElements = Console.ReadLine().Split();
                foreach (var chemicalElement in compoundChemicalElements)
                {
                    uniqueChemicalElements.Add(chemicalElement);
                }
            }

            Console.WriteLine(string.Join(' ', uniqueChemicalElements));
        }
    }
}
