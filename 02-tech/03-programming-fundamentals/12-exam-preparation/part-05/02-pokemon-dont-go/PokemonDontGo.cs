using System;
using System.Linq;

namespace _02_pokemon_dont_go
{
    class PokemonDontGo
    {
        static void Main()
        {
            var distances = Console.ReadLine().Split().Select(int.Parse).ToList();
            var sum = 0L;

            while (distances.Count > 0)
            {
                var index = int.Parse(Console.ReadLine());
                int pokemon;

                if (index < 0)
                {
                    pokemon = distances[0];
                    distances[0] = distances[distances.Count - 1];
                }
                else if (index >= distances.Count)
                {
                    pokemon = distances[distances.Count - 1];
                    distances[distances.Count - 1] = distances[0];
                }
                else
                {
                    pokemon = distances[index];
                    distances.RemoveAt(index);
                }

                for (int i = 0; i < distances.Count; i++)
                {
                    if (distances[i] <= pokemon)
                    {
                        distances[i] += pokemon;
                    }
                    else
                    {
                        distances[i] -= pokemon;
                    }
                }

                sum += pokemon;
            }

            Console.WriteLine(sum);
        }
    }
}
