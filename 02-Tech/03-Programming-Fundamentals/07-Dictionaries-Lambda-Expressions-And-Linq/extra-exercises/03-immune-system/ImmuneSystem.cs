using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03_immune_system
{
    class ImmuneSystem
    {
        static void Main()
        {

#if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
#endif

            var initialHealth = int.Parse(Console.ReadLine());
            var currentHealth = initialHealth;
            var input = Console.ReadLine();
            var encounteredViruses = new HashSet<string>();

            while (input != "end")
            {
                var virus = input;
                var virusStrength = virus.ToCharArray().Select(x => (int)x).Sum() / 3;
                int secondsToDefeat = (virusStrength * virus.Length) / (encounteredViruses.Contains(virus) ? 3 : 1);
                var timeToDefeat = TimeSpan.FromSeconds(secondsToDefeat);
                currentHealth -= secondsToDefeat;
                var regenerationFactor = currentHealth / 5;
                encounteredViruses.Add(virus);

                Console.WriteLine($"Virus {virus}: {virusStrength} => {secondsToDefeat} seconds");
                if (currentHealth > 0)
                {
                    Console.WriteLine($"{virus} defeated in {timeToDefeat.Minutes}m {timeToDefeat.Seconds}s.");
                    Console.WriteLine($"Remaining health: {currentHealth}");
                    currentHealth = ValueOrMax(currentHealth + regenerationFactor, initialHealth);
                }
                else
                {
                    Console.WriteLine("Immune System Defeated.");
                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Final Health: {currentHealth}");
        }

        private static int ValueOrMax(int value, int max)
        {
            if (value > max)
            {
                return max;
            }

            return value;
        }
    }
}
