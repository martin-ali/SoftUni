using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_wardrobe
{
    class Wardrobe
    {
        static void Main()
        {
            var clothesByColor = new Dictionary<string, Dictionary<string, int>>();
            var apparelCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < apparelCount; i++)
            {
                var clothingInfo = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                var color = clothingInfo[0];
                var clothes = clothingInfo.Skip(1);

                if (clothesByColor.ContainsKey(color) == false)
                {
                    clothesByColor[color] = new Dictionary<string, int>();
                }

                foreach (var clothing in clothes)
                {
                    if (clothesByColor[color].ContainsKey(clothing) == false)
                    {
                        clothesByColor[color][clothing] = 0;
                    }

                    clothesByColor[color][clothing]++;
                }
            }

            var clothingToFindData = Console.ReadLine().Split();
            var colorToFind = clothingToFindData[0];
            var typeOfClothingToFind = clothingToFindData[1];

            foreach (var color in clothesByColor)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var clothingAndCount in color.Value)
                {
                    var clothingFoundIndicator = (color.Key == colorToFind && clothingAndCount.Key == typeOfClothingToFind)
                                                ? "(found!)"
                                                : "";
                    Console.WriteLine($"* {clothingAndCount.Key} - {clothingAndCount.Value} {clothingFoundIndicator}");
                }
            }
        }
    }
}
/*

4
Blue -> dress,jeans,hat
Gold -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
Blue dress

4
Red -> hat
Red -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
White tanktop

5
Blue -> shoes
Blue -> shoes,shoes,shoes
Blue -> shoes,shoes
Blue -> shoes
Blue -> shoes,shoes
Red tanktop

 */
