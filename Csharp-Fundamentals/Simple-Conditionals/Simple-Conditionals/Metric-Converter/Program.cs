using System;
using System.Collections.Generic;

namespace Metric_Converter
{
    class Program
    {
        private static Dictionary<string, double> conversionTable = new Dictionary<string, double>()
        {
            ["m"] = 1,
            ["mm"] = 1000,
            ["cm"] = 100,
            ["mi"] = 0.000621371192,
            ["in"] = 39.3700787,
            ["km"] = 0.001,
            ["ft"] = 3.2808399,
            ["yd"] = 1.0936133
        };

        static void Main()
        {
            var value = double.Parse(Console.ReadLine());
            var inputMetric = Console.ReadLine();
            var outputMetric = Console.ReadLine();

            double valueInMeters = value / conversionTable[inputMetric];

            double valueInOutputMetric = valueInMeters * conversionTable[outputMetric];

            Console.WriteLine($"{valueInOutputMetric:0.00000000}");
        }
    }
}
