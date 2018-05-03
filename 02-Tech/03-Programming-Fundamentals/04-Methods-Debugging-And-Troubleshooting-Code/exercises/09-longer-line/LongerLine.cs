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

            var firstLineStart = new Point(x1, y1);
            var firstLineEnd = new Point(x2, y2);
            var secondLineStart = new Point(x3, y3);
            var secondLineEnd = new Point(x4, y4);

            var firstLine = new Line(start: firstLineStart, end: firstLineEnd);
            var secondLine = new Line(start: secondLineStart, end: secondLineEnd);

            var longestLine = GetLongestLine(firstLine, secondLine);
            longestLine = SortLineByDistanceToPoint(longestLine, new Point(0, 0));
            Console.WriteLine($"({longestLine.Start.X}, {longestLine.Start.Y})({longestLine.End.X}, {longestLine.End.Y})");
        }

        // TODO: Needs a better name
        private static Line SortLineByDistanceToPoint(Line line, Point comparisonPoint)
        {
            var start = DistanceBetweenPoints(line.Start, comparisonPoint);
            var end = DistanceBetweenPoints(line.End, comparisonPoint);

            bool endIsCloserToComparisonPointThanStart = (end < start);
            if (endIsCloserToComparisonPointThanStart)
            {
                return new Line(line.End, line.Start);
            }

            return line;
        }

        private static Line GetLongestLine(Line firstLine, Line secondLine)
        {
            var firstLineLength = DistanceBetweenPoints(firstLine.Start, firstLine.End);
            var secondLineLength = DistanceBetweenPoints(secondLine.Start, secondLine.End);

            return (firstLineLength >= secondLineLength ? firstLine : secondLine);
        }

        private static double DistanceBetweenPoints(Point firstPoint, Point secondPoint)
        {
            var horizontalDistance = Math.Pow(firstPoint.X - secondPoint.X, 2);
            var verticalDistance = Math.Pow(firstPoint.Y - secondPoint.Y, 2);
            var distance = Math.Sqrt(horizontalDistance + verticalDistance);

            return distance;
        }
    }

    internal class Line
    {

        public Line(Point start, Point end)
        {
            this.Start = start;
            this.End = end;
        }

        public Point Start { get; set; }

        public Point End { get; set; }
    }

    internal class Point
    {

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }
    }
}
