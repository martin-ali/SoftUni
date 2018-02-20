using System;

namespace Celsius_to_Fahrenheit
{
    class Program
    {
        static void Main()
        {
            var degreesInCelsius = double.Parse(Console.ReadLine());

            var degreesInFahrenheit = (degreesInCelsius * 1.8) + 32;

            Console.WriteLine(degreesInFahrenheit);
        }
    }
}
