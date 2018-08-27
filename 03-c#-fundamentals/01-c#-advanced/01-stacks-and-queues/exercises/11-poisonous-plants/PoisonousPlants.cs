using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _11_poisonous_plants
{
    class PoisonousPlants
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test2.txt"));
#endif

            var plantCount = int.Parse(Console.ReadLine());
            var plants = Console
                        .ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();

            var daysToDeath = new int[plants.Length];
            var previousPlantIndexes = new Stack<int>();
            previousPlantIndexes.Push(0);

            for (int index = 1; index < plants.Length; index++)
            {
                var lastDay = 0;
                while (previousPlantIndexes.Count > 0
                    && plants[previousPlantIndexes.Peek()] >= plants[index])
                {
                    lastDay = Math.Max(lastDay, daysToDeath[previousPlantIndexes.Pop()]);
                }

                if (previousPlantIndexes.Count > 0)
                {
                    daysToDeath[index] = lastDay + 1;
                }

                previousPlantIndexes.Push(index);
            }

            Console.WriteLine(daysToDeath.Max());
        }
    }
}