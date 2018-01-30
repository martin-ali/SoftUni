using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var xIsOnRectangleBorder = (rx1 == px || px == rx2) && (ry1 >= py && py <= ry2);
            var yIsOnRectangleBorder = (ry1 == py || py == ry2) && (rx1 >= px && px <= rx2);
            var pointIsOnRectangleBorder = xIsOnRectangleBorder || yIsOnRectangleBorder;

            if (pointIsOnRectangleBorder)
            {
                var result = pointIsOnRectangleBorder ? "Inside" : "Outside";
                Console.WriteLine(result);
            }

            var xIsInRect = rx1 <= px && px <= rx2;
            var yIsInRect = ry1 <= py && py <= ry2;
            var pointIsInRectangle = xIsInRect && yIsInRect;

            if (pointIsInRectangle)
            {
                var result = pointIsInRectangle ? "Inside" : "Outside";
                Console.WriteLine(result);
            }
        }
    }
}
