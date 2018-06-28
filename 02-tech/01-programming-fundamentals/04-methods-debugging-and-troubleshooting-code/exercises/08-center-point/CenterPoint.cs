using System;

namespace _08_center_point
{
    class CenterPoint
    {
        static void Main()
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            var centerPoint = (x: 0, y: 0);
            var firstPoint = (x: x1, y: y1);
            var secondPoint = (x: x2, y: y2);

            var distanceOfFirstPoint = DistanceBetweenPoints(firstPoint, centerPoint);
            var distanceOfSecondPoint = DistanceBetweenPoints(secondPoint, centerPoint);

            var closestPoint = (distanceOfFirstPoint > distanceOfSecondPoint ? secondPoint : firstPoint);
            Console.WriteLine($"({closestPoint.x}, {closestPoint.y})");
        }

        private static double DistanceBetweenPoints((double x, double y) firstPoint, (double x, double y) secondPoint)
        {
            var horizontalDistance = Math.Pow(firstPoint.x - secondPoint.x, 2);
            var verticalDistance = Math.Pow(firstPoint.y - secondPoint.y, 2);
            var distance = Math.Sqrt(horizontalDistance + verticalDistance);

            return distance;
        }
    }
}
