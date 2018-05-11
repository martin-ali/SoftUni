using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _11_dragon_army
{
    class DragonArmy
    {
        readonly static (int Health, int Damage, int Armor) DefaultStats = (250, 45, 10);

        static void Main()
        {

            #if DEBUG
            Console.SetIn(new StreamReader("./tests/test1.txt"));
            #endif

            var dragonsByType = new Dictionary<string, SortedDictionary<string, (int damage, int health, int armor)>>();
            var numberOfDragons = int.Parse(Console.ReadLine());

            for (int current = 0; current < numberOfDragons; current++)
            {
                var line = Console.ReadLine().Split(' ');

                var type = line[0];
                var name = line[1];
                var dragon =
                (
                    damage: DefaultIfNull(line[2], DefaultStats.Damage),
                    health: DefaultIfNull(line[3], DefaultStats.Health),
                    armor: DefaultIfNull(line[4], DefaultStats.Armor)
                );

                if (dragonsByType.ContainsKey(type) == false)
                {
                    dragonsByType[type] = new SortedDictionary<string, (int damage, int health, int armor)>();
                }

                dragonsByType[type][name] = dragon;
            }

            foreach (var type in dragonsByType)
            {
                var numberOfDragonsOfType = type.Value.Count;
                var average = AverageDragonStats(type.Value.Values, numberOfDragonsOfType);
                Console.WriteLine($"{type.Key}::({average.damage:0.00}/{average.health:0.00}/{average.armor:0.00})");

                // type.Value -> dragons
                foreach (var dragon in type.Value)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.damage}, health: {dragon.Value.health}, armor: {dragon.Value.armor}");
                }
            }
        }

        private static (double damage, double health, double armor) AverageDragonStats(SortedDictionary<string, (int damage, int health, int armor)>.ValueCollection dragons, double numberOfDragons)
        {
            var aggregatedInfo = dragons.Aggregate((aggregation, dragon) =>
            {
                aggregation.damage += dragon.damage;
                aggregation.health += dragon.health;
                aggregation.armor += dragon.armor;

                return aggregation;
            });

            var averageStats =
            (
                aggregatedInfo.damage / numberOfDragons,
                aggregatedInfo.health / numberOfDragons,
                aggregatedInfo.armor / numberOfDragons
            );

            return averageStats;
        }

        private static int DefaultIfNull(string stat, int defaultValue)
        {
            if (stat == "null")
            {
                return defaultValue;
            }

            return int.Parse(stat);
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
