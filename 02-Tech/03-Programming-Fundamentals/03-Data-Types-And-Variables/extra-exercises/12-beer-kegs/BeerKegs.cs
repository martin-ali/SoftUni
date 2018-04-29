using System;
using System.Linq;

namespace _12_beer_kegs
{
    class BeerKegs
    {
        static void Main()
        {
            var numberOfBeerKegs = int.Parse(Console.ReadLine());
            var beerKegs = new(string model, float radius, int height, double volume)[numberOfBeerKegs];

            for (int current = 0; current < numberOfBeerKegs; current++)
            {
                var model = Console.ReadLine();
                var radius = float.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());
                var volume = Math.PI * (radius * radius) * height;

                var keg = (model, radius, height, volume);
                beerKegs[current] = keg;
            }

            var biggestKeg = beerKegs.Aggregate((a, b) => a.volume > b.volume ? a : b);
            Console.WriteLine(biggestKeg.model);
        }
    }
}
