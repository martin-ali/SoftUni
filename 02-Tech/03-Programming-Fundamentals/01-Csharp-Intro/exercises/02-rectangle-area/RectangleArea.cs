using System;

namespace _02_rectangle_area
{
    class RectangleArea
    {
        static void Main()
        {
            float width = float.Parse(Console.ReadLine());
            float height = float.Parse(Console.ReadLine());
            Console.WriteLine($"{width * height:0.00}");
        }
    }
}
