using System;
using System.Linq;
using System.Collections.Generic;

namespace _11_pokemon_trainer
{
    class PokemonTrainer
    {
        static void Main()
        {
            var trainersByName = new Dictionary<string, Trainer>();

            var input = Console.ReadLine();
            while (input != "Tournament")
            {
                var catchInformation = input.Split();
                var trainerName = catchInformation[0];
                var pokemonName = catchInformation[1];
                var element = catchInformation[2];
                var health = int.Parse(catchInformation[3]);

                var pokemon = new Pokemon(pokemonName, health, element);

                if (trainersByName.ContainsKey(trainerName) == false)
                {
                    trainersByName[trainerName] = new Trainer(trainerName);
                }

                trainersByName[trainerName].Pokemon.Add(pokemon);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                var element = input;

                foreach (var trainer in trainersByName)
                {
                    if (trainer.Value.Pokemon.Any(p => p.Element == element))
                    {
                        trainer.Value.BadgeCount++;
                    }
                    else
                    {
                        trainer.Value.Pokemon.ForEach(p => p.Health -= 10);
                        trainer.Value.Pokemon.RemoveAll(p => p.Health <= 0);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var trainer in trainersByName.OrderByDescending(t => t.Value.BadgeCount))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.BadgeCount} {trainer.Value.Pokemon.Count}");
            }
        }
    }
}
