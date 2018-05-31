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
            var weatherByCity = new Dictionary<string, (float temperature, string weatherType)>();

            var input = Console.ReadLine();
            while (input != "end")
            {
                var weatherInformationMatch = pattern.Match(input);
                if (weatherInformationMatch.Success)
                {
                    var city = weatherInformationMatch.Groups[1].Value;
                    var temperature = float.Parse(weatherInformationMatch.Groups[2].Value);
                    var weather = weatherInformationMatch.Groups[3].Value;

                    weatherByCity[city] = (temperature, weather);
                }

                input = Console.ReadLine();
            }

            var orderedWeatherByCity = weatherByCity.OrderBy(city => city.Value.temperature);
            foreach (var city in orderedWeatherByCity)
            {
                Console.WriteLine($"{city.Key} => {city.Value.temperature:0.00} => {city.Value.weatherType}");
            }
        }
    }
}