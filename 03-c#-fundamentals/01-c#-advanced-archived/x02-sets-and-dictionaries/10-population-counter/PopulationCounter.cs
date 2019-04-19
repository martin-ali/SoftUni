using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_population_counter
{
    class PopulationCounter
    {
        static void Main()
        {
            var populationByCountry = new Dictionary<string, long>();
            var populationByCityByCountry = new SortedDictionary<string, SortedDictionary<string, int>>();

            var input = Console.ReadLine();
            while (input != "report")
            {
                var populationData = input.Split('|');
                var city = populationData[0];
                var country = populationData[1];
                var population = int.Parse(populationData[2]);

                if (populationByCountry.ContainsKey(country) == false)
                {
                    populationByCountry[country] = 0;
                }

                if (populationByCityByCountry.ContainsKey(country) == false)
                {
                    populationByCityByCountry[country] = new SortedDictionary<string, int>();
                }

                if (populationByCityByCountry[country].ContainsKey(city) == false)
                {
                    populationByCityByCountry[country][city] = 0;
                }

                populationByCountry[country] += population;
                populationByCityByCountry[country][city] += population;

                input = Console.ReadLine();
            }

            foreach (var country in populationByCityByCountry.OrderByDescending(country => populationByCountry[country.Key]))
            {
                Console.WriteLine($"{country.Key} (total population: {populationByCountry[country.Key]})");

                var cities = country.Value.OrderByDescending(city => populationByCityByCountry[country.Key][city.Key]);
                foreach (var city in cities)
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
/*

Sofia|Bulgaria|1
Veliko Tarnovo|Bulgaria|2
London|UK|4
Rome|Italy|3
report

*/
