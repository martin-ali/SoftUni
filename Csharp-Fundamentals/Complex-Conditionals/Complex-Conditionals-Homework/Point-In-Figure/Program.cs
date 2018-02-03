using System;

namespace Point_In_Figure
{
    class Program
    {
        static void Main()
        {
            var rectangleSize = double.Parse(Console.ReadLine());
            var px = double.Parse(Console.ReadLine());
            var py = double.Parse(Console.ReadLine());

            //var rectangleSize = 15d;
            //var px = 29d;
            //var py = 37d;

            string result = "border";

            var pointIsInFirstRectangle = PointIsInsideRectangle(0, 0, rectangleSize * 3, rectangleSize, px, py);
            var pointIsInSecondRectangle = PointIsInsideRectangle(rectangleSize, 0, rectangleSize * 2, rectangleSize * 4, px, py);
            var pointIsOutsideFirstRectangle = PointIsOutsideRectangle(0, 0, rectangleSize * 3, rectangleSize, px, py);
            var pointIsOutsideSecondRectangle = PointIsOutsideRectangle(rectangleSize, 0, rectangleSize * 2, rectangleSize * 4, px, py);

            bool pointIsInsideShape = pointIsInFirstRectangle || pointIsInSecondRectangle;
            bool pointIsOutsideShape = pointIsOutsideFirstRectangle && pointIsOutsideSecondRectangle;

            if (pointIsInsideShape)
            {
                result = "inside";
            }
            else if (pointIsOutsideShape)
            {
                result = "outside";
            }

            Console.WriteLine(result);
        }

        private static bool PointIsInsideRectangle(double rectangleX, double rectangleY,
                                                double rectangleWidth, double rectangleHeight,
                                                double pointX, double pointY)
        {
            var xIsInRect = rectangleX < pointX && pointX < rectangleWidth;
            var yIsInRect = rectangleY < pointY && pointY < rectangleHeight;

            var pointIsInRectangle = xIsInRect && yIsInRect;
            return pointIsInRectangle;
        }

        private static bool PointIsOutsideRectangle(double rectangleX, double rectangleY,
                                               double rectangleWidth, double rectangleHeight,
                                               double pointX, double pointY)
        {
            var xIsInRect = rectangleX > pointX || pointX > rectangleWidth;
            var yIsInRect = rectangleY > pointY || pointY > rectangleHeight;

            var pointIsInRectangle = xIsInRect || yIsInRect;
            return pointIsInRectangle;
        }
    }
}
