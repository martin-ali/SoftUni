using System;

namespace _02_number_checker
{
    class NumberChecker
    {
        static void Main()
        {
            var number = Console.ReadLine();
            var isNumberFloatingPoint = number.Contains(".");
            var numberType = isNumberFloatingPoint ? "floating-point" : "integer";
            Console.WriteLine(numberType);
        }
    }
}
