using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_hornet_armada
{
    class Program
    {
        private static int index = 0;

        private static string[] testInput = @"6
1 = BlackBeatles -> Soldier:2000
2 = BlackBeatles -> Worker:1000
1 = Red_Ones -> Soldier:10000
5 = Rm -> Soldier:30000
2 = Red_Ones -> Soldier:20000
10 = RND -> Soldier:100000
10\Soldier".Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        static void Main()
        {
            var legions = new Dictionary<string, Dictionary<string, int>>();
            var legionActivity = new Dictionary<string, int>();

            // int numberOfLines = int.Parse(Console.ReadLine());
            int numberOfLines = int.Parse(testInput[index++]);

            while (numberOfLines-- > 0)
            {
                // var rawLine = Console.ReadLine();
                var rawLine = testInput[index++];
                var rawData = rawLine.Split(new char[] { '-', '>', ' ', '=', ':' }, StringSplitOptions.RemoveEmptyEntries);
                var currentLastActivity = int.Parse(rawData[0]);
                var legionName = rawData[1];
                var soldierType = rawData[2];
                var soldierCount = int.Parse(rawData[3]);

                if (legions.ContainsKey(legionName) == false)
                {
                    legions[legionName] = new Dictionary<string, int>();
                    legionActivity[legionName] = 0;
                }

                if (legions[legionName].ContainsKey(soldierType) == false)
                {
                    legions[legionName][soldierType] = 0;
                }

                legions[legionName][soldierType] += soldierCount;
                legionActivity[legionName] = Math.Max(legionActivity[legionName], currentLastActivity);
            }

            // var lastLine = Console.ReadLine();
            var lastLine = testInput[index++];
            if (lastLine.Contains("\\"))
            {
                var rawInfo = lastLine.Split('\\');
                var activity = int.Parse(rawInfo[0]);
                var soldierType = rawInfo[1];

                var rrrrrr = legions
                .Where(l => l.Value.ContainsKey(soldierType) && legionActivity[l.Key] < activity)
                .OrderByDescending(l => l.Value[soldierType]);

                foreach (var item in rrrrrr)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value[soldierType]}");
                }

                // foreach (var legion in legions)
                // {
                //     foreach (var soldier in legion.Value)
                //     {
                //         Console.WriteLine(1);
                //     }
                // }
            }
            else
            {

            }
        }
    }
}
