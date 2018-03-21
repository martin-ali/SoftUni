using System;
using System.Linq;

namespace _03_pokemon_dont_go
{
    class Program
    {
        static void Main()
        {
            var pokemons = Console
                            .ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.None)
                            .Select(long.Parse)
                            .ToList();
            var sum = 0l;

            while (pokemons.Count > 0)
            {
                var index = int.Parse(Console.ReadLine());

                long currentPokemon;
                if (index < 0)
                {
                    currentPokemon = pokemons[0];
                    pokemons[0] = pokemons[pokemons.Count - 1];
                }
                else if (index >= pokemons.Count)
                {
                    currentPokemon = pokemons[pokemons.Count - 1];
                    pokemons[pokemons.Count - 1] = pokemons[0];
                }
                else
                {
                    currentPokemon = pokemons[index];
                    pokemons.RemoveAt(index);
                }

                sum += currentPokemon;
                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= currentPokemon)
                    {
                        pokemons[i] += currentPokemon;
                    }
                    else
                    {
                        pokemons[i] -= currentPokemon;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
