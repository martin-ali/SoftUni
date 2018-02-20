using System;
using System.Linq;

namespace _09_sum_digits
{
    class Program
    {
        static void Main(string[] args)
        {
            // Possible to do with modulo division, but way too late to think
            var number = Console
                            .ReadLine()
                            .ToCharArray()
                            .Select(x => (int)Char.GetNumericValue(x))
                            .ToArray();
            var numberDigitsSum = number.Sum();

            Console.WriteLine(numberDigitsSum);
        }
    }
}
