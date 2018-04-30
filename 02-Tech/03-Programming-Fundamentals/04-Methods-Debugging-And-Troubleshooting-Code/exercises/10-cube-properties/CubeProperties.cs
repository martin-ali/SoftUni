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
                    result = GetCubeFaceDiagonal(side);
                    break;
                case "space":
                    result = GetCubeSpaceDiagonal(side);
                    break;
                case "volume":
                    result = GetCubeVolume(side);
                    break;
                case "area":
                    result = GetCubeSurfaceArea(side);
                    break;
            }

            Console.WriteLine($"{result:0.00}");
        }

        private static double GetCubeSurfaceArea(double side)
        {
            return 6 * (side * side);
        }

        private static double GetCubeVolume(double side)
        {
            return Math.Pow(side, 3);
        }

        private static double GetCubeSpaceDiagonal(double side)
        {
            return Math.Sqrt(3 * (side * side));
        }

        private static double GetCubeFaceDiagonal(double side)
        {
            return Math.Sqrt(2 * (side * side));
        }
    }
}
