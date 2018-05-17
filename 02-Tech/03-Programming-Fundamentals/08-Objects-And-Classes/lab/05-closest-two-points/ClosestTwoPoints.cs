using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05_closest_two_points
{
    class ClosestTwoPoints
    {
        static void Main()
        {
#if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
#endif

            var pointsCount = int.Parse(Console.ReadLine());
            var points = new List<Point>();
            var center = new Point(0, 0);
            for (int i = 0; i < pointsCount; i++)
            {
                var pointData = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var x = pointData[0];
                var y = pointData[1];

                points.Add(new Point(x, y));
            }

            var info = (start: points[0], end: points[1], distance: points[0].DistanceTo(points[1]));
            points = points.OrderBy(p => center.DistanceTo(p)).ToList();
            for (int i = 1; i < points.Count; i++)
            {
                Point current = points[i];
                Point previous = points[i - 1];
                var distance = current.DistanceTo(previous);

                if (distance < info.distance)
                {
                    info = (previous, current, distance);
                }
            }

            Console.WriteLine($"{info.distance:0.000}");
            Console.WriteLine(info.start);
            Console.WriteLine(info.end);
        }
    }


    internal class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public double DistanceTo(Point point)
        {
            var horizontalDistance = point.X - this.X;
            var verticalDistance = point.Y - this.Y;
            var distance = Math.Sqrt((horizontalDistance * horizontalDistance) + (verticalDistance * verticalDistance));

            return distance;
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }
    }
}
