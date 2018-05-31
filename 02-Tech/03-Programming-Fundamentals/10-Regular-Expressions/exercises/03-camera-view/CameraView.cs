using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_camera_view
{
    class CameraView
    {
        static void Main()
        {
            var arguments = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var elements = Console.ReadLine().Split("|<");

            int length = arguments[1];
            int startIndex = arguments[0];

            var result = new List<string>();
            foreach (var element in elements.Skip(1))
            {
                string view = element.Substring(startIndex, Math.Clamp(length, 0, element.Length - startIndex));
                result.Add(view);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
/*

9 7
GreatBigSea|<uglyStuffHawaii|<boriiiingKilauea

0 5
|>invalid|<beach|noMoreCameras

 */
