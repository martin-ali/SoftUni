using System;
using System.Collections.Generic;

namespace _03_decimal_to_binary_converter
{
    class DecimalToBinaryConverter
    {
        static void Main()
        {
            var numberInDecimal = int.Parse(Console.ReadLine());

            var numberInBinary = new Stack<int>();
            do
            {
                var remainder = numberInDecimal % 2;
                numberInBinary.Push(remainder);

                numberInDecimal /= 2;
            }
            while (numberInDecimal > 0);

            Console.WriteLine(string.Join("", numberInBinary));
        }
    }
}
