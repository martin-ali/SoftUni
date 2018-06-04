using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_nether_realms
{
    class NetherRealms
    {
        static void Main()
        {
            var statsByDemon = new SortedDictionary<string, (double damage, int health)>();
            var demons = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var forbiddenCharacters = "+-*/.".ToCharArray();

            foreach (var demon in demons)
            {
                var health = demon
                                .Where(x => !Char.IsDigit(x) && !forbiddenCharacters.Contains(x))
                                .Sum(x => x);

                var damage = 0.0;
                var numberMatches = Regex.Matches(demon, @"-?\d+(\.\d+)?");
                foreach (Match number in numberMatches)
                {
                    damage += double.Parse(number.Value);
                }

                foreach (var symbol in demon)
                {
                    if (symbol == '*')
                    {
                        damage *= 2;
                    }
                    else if (symbol == '/')
                    {
                        damage /= 2;
                    }
                }

                statsByDemon[demon] = (damage, health);
            }

            foreach (var demon in statsByDemon)
            {
                Console.WriteLine($"{demon.Key} - {demon.Value.health} health, {demon.Value.damage:0.00} damage");
            }
        }
    }
}
/*

M3ph-0.5s-0.5t0.0**

M3ph1st0**, Azazel

Gos/ho

 */
