using System;

namespace _08_refactor_volume_of_pyramid
{
    class RefactorVolumeOfPyramid
    {
        static void Main()
        {
            Console.Write("Length: ");
            double length = double.Parse(Console.ReadLine());

            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());

            double volume = (length * width * height) / 3;
            Console.WriteLine($"Pyramid Volume: {volume:F2}");
        }
    }
}
