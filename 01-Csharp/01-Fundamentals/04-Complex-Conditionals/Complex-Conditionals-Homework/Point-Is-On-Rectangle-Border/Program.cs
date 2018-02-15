using System;

namespace Point_Is_On_Rectangle_Border
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

            var result = "Inside / Outside";
            var xIsOnRectangleBorder = (rx1 == px || px == rx2) && (ry1 <= py && py <= ry2);
            var yIsOnRectangleBorder = (ry1 == py || py == ry2) && (rx1 <= px && px <= rx2);
            var pointIsOnRectangleBorder = xIsOnRectangleBorder || yIsOnRectangleBorder;

            if (pointIsOnRectangleBorder)
            {
                result = "Border";
            }

            Console.WriteLine(result);
        }
    }
}
