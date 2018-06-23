using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_pokemon_evolution
{
    class PokemonEvolution
    {
        static void Main()
        {
            var evolutionsByPokemon = new Dictionary<string, List<(string name, long index)>>();
            var input = Console.ReadLine();

            while (input != "wubbalubbadubdub")
            {
                var parameters = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                if (parameters.Length == 3)
                {
                    var pokemon = parameters[0];
                    var evolution = parameters[1];
                    var index = long.Parse(parameters[2]);

                    if (evolutionsByPokemon.ContainsKey(pokemon) == false)
                    {
                        evolutionsByPokemon[pokemon] = new List<(string name, long index)>();
                    }

                    evolutionsByPokemon[pokemon].Add((evolution, index));
                }
                else
                {
                    var pokemon = parameters[0];

                    if (evolutionsByPokemon.ContainsKey(pokemon))
                    {
                        Console.WriteLine($"# {pokemon}");
                        foreach (var evolution in evolutionsByPokemon[pokemon])
                        {
                            Console.WriteLine($"{evolution.name} <-> {evolution.index}");
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var pokemon in evolutionsByPokemon)
            {
                Console.WriteLine($"# {pokemon.Key}");
                var orderedEvolutions = pokemon.Value.OrderByDescending(evo => evo.index);
                foreach (var evolution in orderedEvolutions)
                {
                    Console.WriteLine($"{evolution.name} <-> {evolution.index}");
                }
            }
        }
    }
}
/*

Ekans -> Hybrid -> 100
Nidoran -> Physical -> 150
Ekans -> Psychological -> 50
Jigglypuff -> Hybrid -> 1000
Jigglypuff -> Physical -> 2000
wubbalubbadubdub

Pikachu -> Hybrid -> 100
Meowth -> Physical -> 100
Pikachu -> Psychological -> 50
Meowth -> Physical -> 50
Pikachu -> Hybrid -> 150
Meowth
Pikachu
wubbalubbadubdub

 */
