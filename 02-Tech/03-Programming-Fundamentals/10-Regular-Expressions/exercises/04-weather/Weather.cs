using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_weather
{
    class Weather
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
            #endif

            var pattern = new Regex(@"([A-Z]{2})(\d+\.\d*)([A-Za-z]+)\|(.*)$");
            var cityInformation = new Dictionary<string, (float temperature, string weatherType)>();

            var input = Console.ReadLine();
            while (input != "end")
            {
                var weatherInformation = pattern.Match(input);
                if (weatherInformation.Success)
                {
                    var city = weatherInformation.Groups[1].Value;
                    var temperature = float.Parse(weatherInformation.Groups[2].Value);
                    var weather = weatherInformation.Groups[3].Value;

                    cityInformation[city] = (temperature, weather);
                }

                input = Console.ReadLine();
            }

            var orderedCities = cityInformation.OrderBy(city => city.Value.temperature);
            foreach (var city in orderedCities)
            {
                Console.WriteLine($"{city.Key} => {city.Value.temperature:0.00} => {city.Value.weatherType}");
            }
        }
    }
}