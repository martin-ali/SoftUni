using System;
using System.Numerics;

namespace _01_snowballs
{
    class Snowballs
    {
        static void Main()
        {
            var snowballCount = int.Parse(Console.ReadLine());
            var bestSnowball = (snow: 0, time: 0, quality: 0, value: new BigInteger(0));
            for (int i = 0; i < snowballCount; i++)
            {
                var snowballSnow = int.Parse(Console.ReadLine());
                var snowballTime = int.Parse(Console.ReadLine());
                var snowballQuality = int.Parse(Console.ReadLine());

                var snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);
                if (snowballValue > bestSnowball.value)
                {
                    bestSnowball = (snowballSnow, snowballTime, snowballQuality, snowballValue);
                }
            }

            Console.WriteLine($"{bestSnowball.snow} : {bestSnowball.time} = {bestSnowball.value} ({bestSnowball.quality})");
        }
    }
}
