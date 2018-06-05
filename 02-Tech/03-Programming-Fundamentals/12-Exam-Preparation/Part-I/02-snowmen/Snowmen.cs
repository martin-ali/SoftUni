using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_snowmen
{
    class Snowmen
    {
        private const int Dead = -1;

        static void Main()
        {
            var snowmen = Console.ReadLine().Split().Select(int.Parse).ToList();
            var remainingSnowmen = snowmen.Count;

            while (remainingSnowmen > 1)
            {
                for (int attacker = 0; attacker < snowmen.Count && remainingSnowmen > 1; attacker++)
                {
                    if (snowmen[attacker] == Dead)
                    {
                        continue;
                    }

                    var target = snowmen[attacker] % snowmen.Count;

                    var difference = Math.Abs(attacker - target);

                    if (attacker == target)
                    {
                        Console.WriteLine($"{attacker} performed harakiri");
                        snowmen[attacker] = Dead;
                    }
                    else if (difference % 2 == 0)
                    {
                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                        snowmen[target] = Dead;
                    }
                    else // (difference % 2 == 1)
                    {
                        Console.WriteLine($"{attacker} x {target} -> {target} wins");
                        snowmen[attacker] = Dead;
                    }

                    remainingSnowmen = snowmen.Count(sm => sm != Dead);
                }

                snowmen.RemoveAll(sm => sm == Dead);
            }
        }
    }
}

/*

4 3 2 1 0

25 31 6 9 2 4 7

 */
