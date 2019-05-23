using System;
using System.Collections.Generic;

namespace _06_wardrobe
{
    class Wardrobe
    {
        static void Main()
        {
            var apparelCount = int.Parse(Console.ReadLine());
            var countByApparelByColor = new Dictionary<string, Dictionary<string, int>>();

            for (int line = 0; line < apparelCount; line++)
            {
                var data = Console.ReadLine().Split(new[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                var color = data[0];
                if (countByApparelByColor.ContainsKey(color) == false)
                {
                    countByApparelByColor[color] = new Dictionary<string, int>();
                }

                for (int current = 1; current < data.Length; current++)
                {
                    var apparel = data[current];
                    if (countByApparelByColor[color].ContainsKey(apparel) == false)
                    {
                        countByApparelByColor[color][apparel] = 0;
                    }

                    countByApparelByColor[color][apparel]++;
                }
            }

            var queryData = Console.ReadLine().Split();
            var queryColor = queryData[0];
            var queryApparel = queryData[1];

            foreach (var color in countByApparelByColor)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var apparel in color.Value)
                {
                    var foundQueriedApparel = (color.Key == queryColor && apparel.Key == queryApparel)
                                ? " (found!)"
                                : "";
                    Console.WriteLine($"* {apparel.Key} - {apparel.Value}{foundQueriedApparel}");
                }
            }
        }
    }
}

/*
4
Red -> hat
Red -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
White tanktop
*/
