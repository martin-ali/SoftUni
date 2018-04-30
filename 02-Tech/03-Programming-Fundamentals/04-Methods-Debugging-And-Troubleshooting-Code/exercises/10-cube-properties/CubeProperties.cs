using System;

namespace _10_cube_properties
{
    class CubeProperties
    {
        static void Main()
        {
            var side = double.Parse(Console.ReadLine());
            var parameter = Console.ReadLine();

            var result = 0.0;
            switch (parameter)
            {
                case "face":
                    result = Math.Sqrt(2 * (side * side));
                    break;
                case "space":
                    result = Math.Sqrt(3 * (side * side));
                    break;
                case "volume":
                    result = Math.Pow(side, 3);
                    break;
                case "area":
                    result = 6 * (side * side);
                    break;
            }

            Console.WriteLine($"{result:0.00}");
        }
    }
}
