using System;

namespace Triangle_Area
{
    class Program
    {
        static void Main()
        {
            var side = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var area = side * height / 2;
            var areaRounded = Math.Round(area, 2);

            Console.WriteLine(areaRounded);
        }
    }
}
