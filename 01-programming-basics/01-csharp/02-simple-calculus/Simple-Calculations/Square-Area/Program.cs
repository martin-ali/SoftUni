using System;

namespace Square_Area
{
    class Program
    {
        static void Main()
        {
            Console.Write("a = ");

            var sideA = int.Parse(Console.ReadLine());
            var area = sideA * sideA;

            Console.Write("Square = ");
            Console.WriteLine(area);
        }
    }
}
