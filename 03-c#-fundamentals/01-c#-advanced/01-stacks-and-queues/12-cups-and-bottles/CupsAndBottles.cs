using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_cups_and_bottles
{
    class CupsAndBottles
    {
        static void Main()
        {
            var cups = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).Reverse());
            var bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            var wastedWater = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                var cup = cups.Pop();
                var bottle = bottles.Pop();

                cup -= bottle;

                if (cup > 0)
                {
                    cups.Push(cup);
                }
                else
                {
                    wastedWater -= cup;
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
