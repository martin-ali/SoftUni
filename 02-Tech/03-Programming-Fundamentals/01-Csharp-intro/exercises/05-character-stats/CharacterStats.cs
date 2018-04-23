using System;

namespace _05_character_stats
{
    class CharacterStats
    {
        static void Main()
        {
            var name = Console.ReadLine();
            int currentHealth = int.Parse(Console.ReadLine());
            int maxHealth = int.Parse(Console.ReadLine());
            int currentEnergy = int.Parse(Console.ReadLine());
            int maxEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: |{new string('|', currentHealth).PadRight(maxHealth, '.')}|");
            Console.WriteLine($"Energy: |{new string('|', currentEnergy).PadRight(maxEnergy, '.')}|");
        }
    }
}
