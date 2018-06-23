using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02_hornet_armada
{
    class HornetArmada
    {
        static void Main()
        {
            #if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
            #endif

            var legionsByName = new Dictionary<string, Legion>();
            var lineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < lineCount; i++)
            {
                var data = Console.ReadLine().Split(new[] { " = ", " -> ", ":" }, StringSplitOptions.RemoveEmptyEntries);
                var lastActivity = int.Parse(data[0]);
                var name = data[1];
                var soldierType = data[2];
                var count = int.Parse(data[3]);

                if (legionsByName.ContainsKey(name) == false)
                {
                    legionsByName[name] = new Legion { Name = name, LastActivity = lastActivity };
                }

                if (lastActivity > legionsByName[name].LastActivity)
                {
                    legionsByName[name].LastActivity = lastActivity;
                }

                legionsByName[name].AddSoldierCountByType(soldierType, count);
            }

            var lastLine = Console.ReadLine();
            var filter = lastLine.Split('\\');

            if (filter.Length == 2)
            {
                var lastActivity = int.Parse(filter[0]);
                var soldierType = filter[1];

                var filteredLegionsByName = legionsByName
                                            .Where(l => (l.Value.LastActivity < lastActivity)
                                                        && (l.Value.SoldierCountByType.ContainsKey(soldierType)))
                                            .OrderByDescending(l => l.Value.SoldierCountByType[soldierType]);

                foreach (var legion in filteredLegionsByName)
                {
                    Console.WriteLine($"{legion.Key} -> {legion.Value.SoldierCountByType[soldierType]}");
                }
            }
            else
            {
                var soldierType = filter[0];

                var filteredLegionsByName = legionsByName
                                            .Where(l => l.Value.SoldierCountByType.ContainsKey(soldierType))
                                            .OrderByDescending(l => l.Value.LastActivity);

                foreach (var legion in filteredLegionsByName)
                {
                    Console.WriteLine($"{legion.Value.LastActivity} : {legion.Key}");
                }
            }
        }
    }

    internal class Legion
    {
        public string Name { get; set; }

        public long SoldierCount { get; set; }

        public int LastActivity { get; set; }

        public Dictionary<string, long> SoldierCountByType { get; set; } = new Dictionary<string, long>();

        public void AddSoldierCountByType(string type, int count)
        {
            if (this.SoldierCountByType.ContainsKey(type) == false)
            {
                this.SoldierCountByType[type] = 0;
            }

            this.SoldierCountByType[type] += count;
            this.SoldierCount += count;
        }
    }
}
