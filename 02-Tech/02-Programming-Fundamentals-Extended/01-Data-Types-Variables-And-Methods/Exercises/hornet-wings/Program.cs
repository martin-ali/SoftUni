using System;

namespace hornet_wings
{
    class Program
    {
        static void Main()
        {
            int wingflaps = int.Parse(Console.ReadLine());
            double distancePer1000Flaps = double.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            var restTime = (wingflaps / endurance) * 5;
            var distanceTraveled = (wingflaps / 1000) * distancePer1000Flaps;
            var time = wingflaps / 100;

            Console.WriteLine($"{distanceTraveled:0.00} m.");
            Console.WriteLine($"{time+restTime} s.");
        }
    }
}
