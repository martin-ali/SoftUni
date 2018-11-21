using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_rectangle_intersection
{
    class RectangleIntersection
    {
        static void Main()
        {
            var parameters = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
            var rectangleCount = parameters[0];
            var checkCount = parameters[1];

            var rectangleById = new Dictionary<string, Rectangle>();
            for (int i = 0; i < rectangleCount; i++)
            {
                var data = Console.ReadLine().Split();
                var id = data[0];
                var width = int.Parse(data[1]);
                var height = int.Parse(data[2]);
                var x = double.Parse(data[3]);
                var y = double.Parse(data[4]);

                var rectangle = new Rectangle(id, width, height, new Point(x, y));
                rectangleById[id] = rectangle;
            }

            for (int i = 0; i < checkCount; i++)
            {
                var data = Console.ReadLine().Split();
                var firstRectangle = rectangleById[data[0]];
                var secondRectangle = rectangleById[data[1]];

                Console.WriteLine(firstRectangle.DoesItIntersect(secondRectangle).ToString().ToLower());
            }
        }
    }
}
/*

2 1
Pego 10 10 2 2
Shosho 5 5 3 3
Pego Shosho

*/
