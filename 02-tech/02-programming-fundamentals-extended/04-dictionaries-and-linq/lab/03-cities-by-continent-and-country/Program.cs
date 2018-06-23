using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_cities_by_continent_and_country
{
    public static class Extensions
    {
        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out T third)
        {

            first = list.Count > 0 ? list[0] : default(T);
            second = list.Count > 1 ? list[1] : default(T);
            third = list.Count > 2 ? list[2] : default(T);
        }
    }

    class Program
    {
        static void Main()
        {
            var map = new Dictionary<string, Dictionary<string, List<string>>>();
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var (continent, country, city) = Console.ReadLine().Split(' ');

                if (map.ContainsKey(continent) == false)
                {
                    map[continent] = new Dictionary<string, List<string>>();
                }

                if (map[continent].ContainsKey(country) == false)
                {
                    map[continent][country] = new List<string>();
                }

                map[continent][country].Add(city);
            }

            foreach (var continent in map)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {String.Join(", ", country.Value)}");
                }
            }
        }
    }
}
