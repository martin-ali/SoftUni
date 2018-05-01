using System;

namespace _11_geometry_calculator
{
    class GeometryCalculator
    {
        static void Main()
        {
            var figure = Console.ReadLine();
            var area = 0.0;
            // FIXME: Using explicit scopes. Better way?
            switch (figure.ToLower())
            {
                case "triangle":
                    {
                        var side = double.Parse(Console.ReadLine());
                        var height = double.Parse(Console.ReadLine());
                        area = GetTriangleArea(side, height);
                    }
                    break;

                case "square":
                    {
                        var side = double.Parse(Console.ReadLine());
                        area = GetRectangleArea(side, side);
                    }
                    break;

                case "rectangle":
                    {
                        var width = double.Parse(Console.ReadLine());
                        var height = double.Parse(Console.ReadLine());
                        area = GetRectangleArea(width, height);
                    }
                    break;

                case "circle":
                    {
                        var radius = double.Parse(Console.ReadLine());
                        area = GetCircleArea(radius);
                    }
                    break;
            }

            Console.WriteLine($"{area:0.00}");
        }

        private static double GetCircleArea(double radius)
        {
            return Math.PI * (radius * radius);
        }

        private static double GetRectangleArea(double width, double height)
        {
            return width * height;
        }

        private static double GetTriangleArea(double side, double height)
        {
            return (side * height) / 2;
        }
    }
}
