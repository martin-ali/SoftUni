using System;

namespace Rectangle_Area_in_Plane
{
    class Program
    {
        static void Main()
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            var leftSide = Math.Abs(y2 - y1);
            var bottomSide = Math.Abs(x1 - x2);

            var area = leftSide * bottomSide;
            var perimeter = 2 * (leftSide + bottomSide);

            Console.WriteLine(area);
            Console.WriteLine(perimeter);
        }
    }
}
