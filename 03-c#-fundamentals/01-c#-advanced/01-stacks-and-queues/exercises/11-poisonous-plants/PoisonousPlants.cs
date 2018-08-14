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
                        .ToList();

            var day = 0;
            var plantsHaveDied = true;
            while (plantsHaveDied)
            {
                plantsHaveDied = false;
                for (int i = plants.Count - 1; i > 0; i--)
                {
                    if (plants[i - 1] < plants[i])
                    {
                        plants[i] = -1;
                        plantsHaveDied = true;
                    }
                }

                if (plantsHaveDied)
                {
                    day++;
                    plants.RemoveAll(x => x < 0);
                }
            }

            Console.WriteLine(day);
        }
    }
}
/*
7
6 5 8 4 7 10 9
 */
