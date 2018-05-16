using System;
using System.IO;
using System.Linq;

namespace _03_intersection_of_circles
{
    class IntersectionOfCircles
    {
        static void Main()
        {
            #if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
            #endif

            var firstCircleParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var secondCircleParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var firstCircle = new Circle(new Point(firstCircleParameters[0], firstCircleParameters[1]), firstCircleParameters[2]);
            var secondCircle = new Circle(new Point(secondCircleParameters[0], secondCircleParameters[1]), secondCircleParameters[2]);

            var doTheyIntersect = (Intersect(firstCircle, secondCircle) ? "Yes" : "No");
            Console.WriteLine(doTheyIntersect);
        }

        private static bool Intersect(Circle firstCircle, Circle secondCircle)
        {
            var horizontalDistance = Math.Pow(firstCircle.Center.X - secondCircle.Center.X, 2);
            var verticalDistance = Math.Pow(firstCircle.Center.Y - secondCircle.Center.Y, 2);
            var distance = Math.Sqrt(horizontalDistance + verticalDistance);

            int sumOfRadii = firstCircle.Radius + secondCircle.Radius;
            var doTheyIntersect = (distance <= sumOfRadii ? true : false);
            return doTheyIntersect;
        }
    }

    internal class Circle
    {
        public Circle(Point center, int radius)
        {
            Center = center;
            Radius = radius;
        }

        public int Radius { get; set; }

        public Point Center { get; set; }
    }

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
