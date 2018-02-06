using System;
using System.Collections.Generic;

namespace Operations_With_Numbers
{
    class Program
    {
        private delegate T ArithmeticDelegate<T>(T x, T y);

        private static Dictionary<char, ArithmeticDelegate<double>> calculate = new Dictionary<char, ArithmeticDelegate<double>>()
        {
            ['+'] = new ArithmeticDelegate<double>((x, y) => x + y),
            ['-'] = new ArithmeticDelegate<double>((x, y) => x - y),
            ['*'] = new ArithmeticDelegate<double>((x, y) => x * y),
            ['/'] = new ArithmeticDelegate<double>((x, y) => x / y),
            ['%'] = new ArithmeticDelegate<double>((x, y) => x % y),
        };

        static void Main()
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var operation = Console.ReadLine()[0];

            if ((operation == '/' || operation == '%') && (firstNumber == 0 || secondNumber == 0))
            {
                Console.WriteLine($"Cannot divide {firstNumber} by zero");
            }
            else
            {
                var result = calculate[operation](firstNumber, secondNumber);
                string additionalInformation = "";

                bool operationIsAdditionSubtractionOrMultiplication = "+-*".IndexOf(operation) >= 0;
                if (operationIsAdditionSubtractionOrMultiplication)
                {
                    additionalInformation = result % 2 == 0 ? " - even" : " - odd";
                }

                var resultFormat = (operation == '/') ? "0.00" : "0";
                Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {result.ToString(resultFormat)}{additionalInformation}");
            }
        }
    }
}
