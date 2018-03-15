using System;
using System.Numerics;

namespace poke_mon
{
    class Program
    {
        static void Main()
        {
            int pokePowerStart = int.Parse(Console.ReadLine());
            int distanceBetweenTargets = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int pokePower = pokePowerStart;
            int targetsPoked = 0;

            while (pokePower >= distanceBetweenTargets)
            {
                pokePower -= distanceBetweenTargets;
                targetsPoked++;

                if (pokePower * 2 == pokePowerStart && exhaustionFactor > 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(targetsPoked);
        }
    }
}
