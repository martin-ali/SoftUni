using System;
using System.Collections.Generic;
using System.Linq;

namespace _14_dragon_army
{
    class DragonArmy
    {
        static void Main()
        {
            var dragonsByType = new Dictionary<string, SortedDictionary<string, (int damage, int health, int armor)>>();
            var dragonCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < dragonCount; i++)
            {
                var dragonData = Console.ReadLine().Split();
                var type = dragonData[0];
                var name = dragonData[1];
                var damage = GetIntValueOrNull(dragonData[2]) ?? 45;
                var health = GetIntValueOrNull(dragonData[3]) ?? 250;
                var armor = GetIntValueOrNull(dragonData[4]) ?? 10;

                if (dragonsByType.ContainsKey(type) == false)
                {
                    dragonsByType[type] = new SortedDictionary<string, (int damage, int health, int armor)>();
                }

                dragonsByType[type][name] = (damage, health, armor);
            }

            foreach (var type in dragonsByType)
            {
                var averageDamage = type.Value.Average(d => d.Value.damage);
                var averageHealth = type.Value.Average(d => d.Value.health);
                var averageArmor = type.Value.Average(d => d.Value.armor);

                Console.WriteLine($"{type.Key}::({averageDamage}/{averageHealth}/{averageArmor})");

                foreach (var dragon in type.Value)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.damage}, health: {dragon.Value.health}, armor: {dragon.Value.armor}");
                }
            }
        }

        private static int? GetIntValueOrNull(string value)
        {
            if (int.TryParse(value, out int number))
            {
                return number;
            }

            return null;
        }
    }
}
/*

5
Red Bazgargal 100 2500 25
Black Dargonax 200 3500 18
Red Obsidion 220 2200 35
Blue Kerizsa 60 2100 20
Blue Algordox 65 1800 50

4
Gold Zzazx null 1000 10
Gold Traxx 500 null 0
Gold Xaarxx 250 1000 null
Gold Ardrax 100 1055 50

*/
