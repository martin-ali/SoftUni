using System;

namespace _01_poke_mon
{
    class PokeMon
    {
        static void Main()
        {
            var startPower = int.Parse(Console.ReadLine());
            var distanceBetweenTargets = int.Parse(Console.ReadLine());
            var exhaustionFactor = int.Parse(Console.ReadLine());

            var targetsPoked = 0;
            var power = startPower;
            while (power >= distanceBetweenTargets)
            {
                power -= distanceBetweenTargets;
                targetsPoked++;

                if ((power * 2) == startPower && exhaustionFactor > 0)
                {
                    power /= exhaustionFactor;
                }
            }

            Console.WriteLine(power);
            Console.WriteLine(targetsPoked);
        }
    }
}
