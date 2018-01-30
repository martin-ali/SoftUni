using System;

namespace Point_In_rectangle
{
    class Program
    {
        static void Main()
        {
            var ry1 = double.Parse(Console.ReadLine());
            var rx1 = double.Parse(Console.ReadLine());
            var ry2 = double.Parse(Console.ReadLine());
            var rx2 = double.Parse(Console.ReadLine());
            var py = double.Parse(Console.ReadLine());
            var px = double.Parse(Console.ReadLine());

            var xIsInRect = rx1 <= px && px <= rx2;
            var yIsInRect = ry1 <= py && py <= ry2;
            var pointIsInRectangle = xIsInRect && yIsInRect;

            var result = pointIsInRectangle ? "Inside" : "Outside";
            Console.WriteLine(result);
        }
    }
}
