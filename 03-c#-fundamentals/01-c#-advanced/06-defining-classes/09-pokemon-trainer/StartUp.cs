using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_pokemon_trainer
{
    class StartUp
    {
        static void Main()
        {
            var trainersByName = new Dictionary<string, Trainer>();
            var input = Console.ReadLine();
            while (input != "Tournament")
            {
                var data = input.Split();
                var trainerName = data[0];
                var pokemonName = data[1];
                var pokemonElement = data[2];
                var pokemonHealth = int.Parse(data[3]);

                if (trainersByName.ContainsKey(trainerName) == false)
                {
                    trainersByName[trainerName] = new Trainer(trainerName);
                }

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainersByName[trainerName].Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }

            var element = Console.ReadLine();
            while (element != "End")
            {
                foreach (var trainer in trainersByName)
                {
                    var pokemons = trainer.Value.Pokemons;
                    if (pokemons.Any(pokemon => pokemon.Element == element))
                    {
                        trainer.Value.BadgeCount++;
                    }
                    else
                    {
                        pokemons.ForEach(pokemon => pokemon.Health -= 10);
                        pokemons.RemoveAll(pokemon => pokemon.Health <= 0);
                    }
                }

                element = Console.ReadLine();
            }

            foreach (var trainer in trainersByName.OrderByDescending(trainer => trainer.Value.BadgeCount))
            {
                Console.WriteLine(trainer.Value);
            }
        }
    }
}
