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

            var longestLine = GetLongestLine(firstPoint, secondPoint, thirdPoint, fourthPoint);
            Console.WriteLine($"({longestLine.start.x}, {longestLine.start.y})({longestLine.end.x}, {longestLine.end.y})");
        }

        private static ((double x, double y) start, (double x, double y) end) GetLongestLine((double x, double y) firstLineStart, (double x, double y) firstLineEnd, (double x, double y) secondLineStart, (double x, double y) secondLineEnd)
        {
            var secondPointIsCloserThanFirst = DistanceBetweenPoints(firstLineEnd, (0, 0)) < DistanceBetweenPoints(firstLineStart, (0, 0));
            if (secondPointIsCloserThanFirst)
            {
                (firstLineStart, firstLineEnd) = (firstLineEnd, firstLineStart);
            }

            var fourthPointIsCloserThanThird = DistanceBetweenPoints(secondLineEnd, (0, 0)) < DistanceBetweenPoints(secondLineStart, (0, 0));
            if (fourthPointIsCloserThanThird)
            {
                (secondLineStart, secondLineEnd) = (secondLineEnd, secondLineStart);
            }

            var firstLine = (start: firstLineStart, end: firstLineEnd);
            var secondLine = (start: secondLineStart, end: secondLineEnd);

            var firstLineLength = DistanceBetweenPoints(firstLineStart, firstLineEnd);
            var secondLineLength = DistanceBetweenPoints(secondLineStart, secondLineEnd);

            var longestLine = (firstLineLength >= secondLineLength ? firstLine : secondLine);
            return longestLine;
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
