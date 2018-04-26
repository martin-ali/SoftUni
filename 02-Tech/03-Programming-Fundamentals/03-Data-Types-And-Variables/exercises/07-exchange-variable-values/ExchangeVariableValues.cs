using System;

namespace _07_exchange_variable_values
{
    class ExchangeVariableValues
    {
        static void Main()
        {
            var a = 5;
            var b = 10;

            Console.WriteLine($"Before:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");

            (a, b) = (b, a);

            Console.WriteLine($"After:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
        }
    }
}
