using System;

namespace _09_longer_line
{
    class LongerLine
    {
        private static Point center = new Point(0, 0);

        static void Main()
        {
            var lines = new Line[2];
            for (int i = 0; i < lines.Length; i++)
            {
                var x1 = double.Parse(Console.ReadLine());
                var y1 = double.Parse(Console.ReadLine());
                var x2 = double.Parse(Console.ReadLine());
                var y2 = double.Parse(Console.ReadLine());

                var start = new Point(x1, y1);
                var end = new Point(x2, y2);
                var line = new Line(start, end);
                lines[i] = line;
            }

            var longestLine = MaxLengthLine(lines[0], lines[1]);
            longestLine = OrderPointsByDistanceToPoint(longestLine, center);
            Console.WriteLine($"({longestLine.Start.X}, {longestLine.Start.Y})({longestLine.End.X}, {longestLine.End.Y})");
        }

        private static Line OrderPointsByDistanceToPoint(Line line, Point comparisonPoint)
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

        private static Line MaxLengthLine(Line firstLine, Line secondLine)
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
