using System;

namespace _05_weather_forecast
{
    class WeatherForecast
    {
        static void Main()
        {
            var numberString = Console.ReadLine();

            var number = double.Parse(numberString);
            var weather = string.Empty;

            // Check if number is floating-point
            if (number % 1 != 0)
            {
                weather = "Rainy";
            }
            else if (sbyte.MinValue <= number && number <= sbyte.MaxValue)
            {
                weather = "Sunny";
            }
            else if (int.MinValue <= number && number <= int.MaxValue)
            {
                weather = "Cloudy";
            }
            else if (long.MinValue <= number && number <= long.MaxValue)
            {
                weather = "Windy";
            }

            Console.WriteLine(weather);
        }
    }
}
