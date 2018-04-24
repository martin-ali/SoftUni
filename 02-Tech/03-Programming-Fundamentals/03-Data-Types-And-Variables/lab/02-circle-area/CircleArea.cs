using System;

namespace _02_circle_area
{
    class CircleArea
    {
        static void Main()
        {
            double radius = double.Parse(Console.ReadLine());
            Console.WriteLine($"{Math.PI * radius * radius:f12}");
        }
    }
}