using System;

namespace _03_water_overflow
{
    class WaterOverflow
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            var currentWaterVolume = 0;
            while (numberOfLines-- > 0)
            {
                int waterToPour = int.Parse(Console.ReadLine());

                if (currentWaterVolume + waterToPour > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    currentWaterVolume += waterToPour;
                }
            }

            Console.WriteLine(currentWaterVolume);
        }
    }
}
