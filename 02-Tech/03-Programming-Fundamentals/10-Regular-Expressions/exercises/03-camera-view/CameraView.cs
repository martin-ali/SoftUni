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

            var result = new List<string>();
            foreach (var element in elements.Skip(1))
            {
                string view = string.Join("", element.Skip(arguments[0]).Take(arguments[1]));
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
