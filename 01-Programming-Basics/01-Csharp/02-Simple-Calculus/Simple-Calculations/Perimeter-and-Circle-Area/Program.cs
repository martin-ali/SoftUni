using System;

namespace Perimeter_and_Circle_Area
{
    class Program
    {
        static void Main()
        {
            var radius = double.Parse(Console.ReadLine());

            var area = Math.PI * radius * radius;
            var perimeter = 2 * Math.PI * radius;

            Console.WriteLine(area);
            Console.WriteLine(perimeter);
        }
    }
}
