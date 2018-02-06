using System;
using System.Collections.Generic;

namespace Operations_With_Numbers
{
    class Program
    {
        private delegate T ArithmeticDelegate<T>(T x, T y);

        private static Dictionary<char, ArithmeticDelegate<int>> calculate = new Dictionary<char, ArithmeticDelegate<int>>()
        {
            ['+'] = new ArithmeticDelegate<int>((x, y) => x + y),
            ['-'] = new ArithmeticDelegate<int>((x, y) => x - y),
            ['*'] = new ArithmeticDelegate<int>((x, y) => x * y),
            ['/'] = new ArithmeticDelegate<int>((x, y) => x / y),
            ['%'] = new ArithmeticDelegate<int>((x, y) => x % y),
        };

        static void Main()
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var operation = Console.ReadLine()[0];

            try
            {
                var result = calculate[operation](firstNumber, secondNumber);
                string additionalInformation;

                bool operationIsAdditionSubtractionOrMultiplication = "+-*".IndexOf(operation) >= 0;
                if (operationIsAdditionSubtractionOrMultiplication)
                {
                    additionalInformation = result % 2 == 0 ? "even" : "odd";
                }
                else if (operation == '/')
                {
                    additionalInformation = result % 2 == 0 ? "even" : "odd";
                }
                else
                {
                    additionalInformation = result % 2 == 0 ? "even" : "odd";
                }

                Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {result} - {additionalInformation}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Cannot divide {firstNumber} by zero");
            }

        }
    }
}
