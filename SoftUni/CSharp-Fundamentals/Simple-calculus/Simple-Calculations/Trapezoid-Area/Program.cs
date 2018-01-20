using System;

namespace Trapezoid_Area
{
    class Program
    {
        static void Main()
        {
            var firstBase = double.Parse(Console.ReadLine());
            var secondBase = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var area = (firstBase + secondBase) * height / 2;

            Console.WriteLine(area);
        }
    }
}
