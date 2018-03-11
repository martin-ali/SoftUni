using System;

namespace travel
{
    class Program
    {
        static void Main()
        {
            // double distance = 100;
            // double truckSpeed = 20;
            // double speedDifference = 500;

            double distance = double.Parse(Console.ReadLine());
            double truckSpeed = double.Parse(Console.ReadLine());
            double speedDifference = double.Parse(Console.ReadLine());

            double timeTruckTakes = distance / truckSpeed;
            double carSpeed = truckSpeed + (speedDifference * 3.6);
            double timeCarTakes = distance / carSpeed;

            Console.WriteLine($"The truck arrived after {Math.Ceiling(timeTruckTakes)} hours");
            Console.WriteLine($"The car arrived after {Math.Ceiling(timeCarTakes)} hours");
        }
    }
}
