using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07_population_counter
{
    class PopulationCounter
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("tests/test2.txt"));
            #endif

            var countriesCitiesAndPopulations = new Dictionary<string, SortedDictionary<string, long>>();
            var countriesAndTheirPopulation = new Dictionary<string, long>();

            var parameters = Console.ReadLine().Split('|');
            while (parameters[0] != "report")
            {
                var city = parameters[0];
                var country = parameters[1];
                var population = int.Parse(parameters[2]);

                if (countriesCitiesAndPopulations.ContainsKey(country) == false)
                {
                    countriesCitiesAndPopulations[country] = new SortedDictionary<string, long>();
                }

                if (countriesAndTheirPopulation.ContainsKey(country) == false)
                {
                    countriesAndTheirPopulation[country] = 0;
                }

                countriesCitiesAndPopulations[country][city] = population;
                countriesAndTheirPopulation[country] += population;

                parameters = Console.ReadLine().Split('|');
            }

            var sortedCountries = countriesAndTheirPopulation.OrderByDescending(country => country.Value);
            foreach (var country in sortedCountries)
            {
                Console.WriteLine($"{country.Key} (total population: {countriesAndTheirPopulation[country.Key]})");

                var sortedCities = countriesCitiesAndPopulations[country.Key].OrderByDescending(city => city.Value);
                foreach (var city in sortedCities)
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
