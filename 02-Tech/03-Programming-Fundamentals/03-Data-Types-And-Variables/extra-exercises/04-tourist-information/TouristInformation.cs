using System;
using System.Collections.Generic;

namespace _04_tourist_information
{
    class TouristInformation
    {

        private static Dictionary<string, double> conversionTable = new Dictionary<string, double>
        {
            ["miles"] = 1.6,
            ["inches"] = 2.54,
            ["feet"] = 30,
            ["yards"] = 0.91,
            ["gallons"] = 3.8
        };

        private static Dictionary<string, string> metricUnitCounterpart = new Dictionary<string, string>
        {
            ["miles"] = "kilometers",
            ["inches"] = "centimeters",
            ["feet"] = "centimeters",
            ["yards"] = "meters",
            ["gallons"] = "liters"
        };

        static void Main()
        {
            var imperialUnit = Console.ReadLine();
            double valueInImperial = double.Parse(Console.ReadLine());
            var valueInMetric = valueInImperial * conversionTable[imperialUnit];
            Console.WriteLine($"{valueInImperial} {imperialUnit} = {valueInMetric:0.00} {metricUnitCounterpart[imperialUnit]}");
        }
    }
}
