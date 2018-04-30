using System;

namespace _09_longer_line
{
    class LongerLine
    {
        static void Main()
        {
            // First Line
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            // Second line
            var x3 = double.Parse(Console.ReadLine());
            var y3 = double.Parse(Console.ReadLine());
            var x4 = double.Parse(Console.ReadLine());
            var y4 = double.Parse(Console.ReadLine());

            var firstPoint = (x: x1, y: y1);
            var secondPoint = (x: x2, y: y2);
            var thirdPoint = (x: x3, y: y3);
            var fourthPoint = (x: x4, y: y4);

            var secondPointIsCloserThanFirst = DistanceBetweenPoints(secondPoint, (0, 0)) < DistanceBetweenPoints(firstPoint, (0, 0));
            if (secondPointIsCloserThanFirst)
            {
                (firstPoint, secondPoint) = (secondPoint, firstPoint);
            }

            var fourthPointIsCloserThanThird = DistanceBetweenPoints(fourthPoint, (0, 0)) < DistanceBetweenPoints(thirdPoint, (0, 0));
            if (fourthPointIsCloserThanThird)
            {
                (thirdPoint, fourthPoint) = (fourthPoint, thirdPoint);
            }

            var firstLine = (start: firstPoint, end: secondPoint);
            var secondLine = (start: thirdPoint, end: fourthPoint);

            var firstLineLength = DistanceBetweenPoints(firstPoint, secondPoint);
            var secondLineLength = DistanceBetweenPoints(thirdPoint, fourthPoint);

            var longestLine = (firstLineLength >= secondLineLength ? firstLine : secondLine);
            Console.WriteLine($"({longestLine.start.x}, {longestLine.start.y})({longestLine.end.x}, {longestLine.end.y})");
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
