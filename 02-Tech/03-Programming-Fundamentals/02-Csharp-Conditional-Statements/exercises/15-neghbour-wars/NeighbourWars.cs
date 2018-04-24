using System;

namespace _15_neghbour_wars
{
    class NeighbourWars
    {
        static void Main()
        {
            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());

            var pesho = (damage: peshoDamage, health: 100, attackName: "Roundhouse kick", name: "Pesho");
            var gosho = (damage: goshoDamage, health: 100, attackName: "Thunderous fist", name: "Gosho");

            var attacker = pesho;
            var defender = gosho;
            for (int round = 1; true; round++)
            {
                defender.health -= attacker.damage;

                if (defender.health <= 0)
                {
                    Console.WriteLine($"{attacker.name} won in {round}th round.");
                    break;
                }

                Console.WriteLine($"{attacker.name} used {attacker.attackName} and reduced {defender.name} to {defender.health} health.");

                if (round % 3 == 0)
                {
                    attacker.health += 10;
                    defender.health += 10;
                }

                (attacker, defender) = (defender, attacker);
            }
        }
    }
}
