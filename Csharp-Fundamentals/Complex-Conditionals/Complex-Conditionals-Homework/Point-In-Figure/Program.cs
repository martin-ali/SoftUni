using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_In_Figure
{
    class Program
    {
        static void Main()
        {
            var rectangleSize = double.Parse(Console.ReadLine());
            var px = double.Parse(Console.ReadLine());
            var py = double.Parse(Console.ReadLine());

            string result = "border";

            bool pointIsInsideShape = PointIsInsideRectangle(rectangleSize, rectangleSize, rectangleSize, rectangleSize, px, py)
                                        && PointIsInsideRectangle(rectangleSize, rectangleSize, rectangleSize, rectangleSize, px, py);
            bool pointIsOutsideShape = PointIsOutsideRectangle(rectangleSize, rectangleSize, rectangleSize, rectangleSize, px, py)
                                        && PointIsOutsideRectangle(rectangleSize, rectangleSize, rectangleSize, rectangleSize, px, py);

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
