using System;

namespace Radians_to_Degrees
{
    class Program
    {
        static void Main()
        {
            var angleInRadians = double.Parse(Console.ReadLine());

            var angleInDegrees = angleInRadians * (180 / Math.PI);
            var roundedAngle = Math.Round(angleInDegrees);

            Console.WriteLine(roundedAngle);
        }
    }
}
