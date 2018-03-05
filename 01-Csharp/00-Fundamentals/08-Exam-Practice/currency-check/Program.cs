using System;
using System.Linq;

namespace currency_check
{
    class Program
    {
        static void Main()
        {
            decimal rubles = (decimal.Parse(Console.ReadLine()) / 100) * 3.5m;
            decimal dollars = decimal.Parse(Console.ReadLine()) * 1.5m;
            decimal euros = decimal.Parse(Console.ReadLine()) * 1.95m;
            decimal levaA = decimal.Parse(Console.ReadLine()) / 2;
            decimal levaB = decimal.Parse(Console.ReadLine());

            decimal cheapestOption = new decimal[] { rubles, dollars, euros, levaA, levaB }.Min();
            Console.WriteLine($"{cheapestOption:0.00}");
        }
    }
}
