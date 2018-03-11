using System;

namespace house_painting
{
    class Program
    {
        static void Main()
        {
            double houseHeight = double.Parse(Console.ReadLine());
            double houseSideLength = double.Parse(Console.ReadLine());
            double roofHeight = double.Parse(Console.ReadLine());

            // double houseHeight = 6;
            // double houseSideLength = 10;
            // double roofHeight = 5.2;

            // Preparation
            double greenPaintLiterPerSqMeters = 3.4;
            double redPaintLiterPerSqMeters = 4.3;
            double windowArea = 1.5 * 1.5;
            double doorArea = 2 * 1.2;
            double houseFrontArea = houseHeight * houseHeight - doorArea;
            double houseBackArea = houseHeight * houseHeight;

            // Sides for green paint
            double FrontAndBackArea = houseFrontArea + houseBackArea;
            double sideWallsArea = 2 * (houseHeight * houseSideLength - windowArea);
            double greenPaintNeeded = (FrontAndBackArea + sideWallsArea) / greenPaintLiterPerSqMeters;

            // Roof for red paint
            double roofSidesArea = 2 * houseHeight * houseSideLength;
            double roofFrontAndBackArea = roofHeight * houseHeight;
            double redPaintNeeded = (roofSidesArea + roofFrontAndBackArea) / redPaintLiterPerSqMeters;

            Console.WriteLine($"{greenPaintNeeded:0.00}");
            Console.WriteLine($"{redPaintNeeded:0.00}");
        }
    }
}
