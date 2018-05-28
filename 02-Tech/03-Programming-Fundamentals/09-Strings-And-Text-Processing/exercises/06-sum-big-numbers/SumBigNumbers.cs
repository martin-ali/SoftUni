using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _06_sum_big_numbers
{
    class SumBigNumbers
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader($"tests/test2.txt"));
#endif

            var firstNumber = Console.ReadLine();
            var secondNumber = Console.ReadLine();

            var sum = SumBigIntegers(firstNumber, secondNumber);
            Console.WriteLine(sum);
        }

        private static string SumBigIntegers(string firstNumber, string secondNumber)
        {
            var length = Math.Max(firstNumber.Length, secondNumber.Length);

            var firstNumberDigits = firstNumber.PadLeft(length, '0');
            var secondNumberDigits = secondNumber.PadLeft(length, '0');
            var result = new Stack<int>();

            // Doable with Zip()
            var remainder = 0;
            for (int i = firstNumberDigits.Length - 1; i >= 0; i--)
            {
                var firstNumberDigit = firstNumberDigits[i] - 48;
                var secondNumberDigit = secondNumberDigits[i] - 48;
                var sum = firstNumberDigit + secondNumberDigit + remainder;

                if (sum > 9)
                {
                    sum -= 10;
                    remainder = 1;
                }
                else
                {
                    remainder = 0;
                }

                result.Push(sum);
            }

            if (remainder == 1) result.Push(remainder);

            return string.Join("", result);
        }
    }
}
/*

      92384723893198319|2|4|6|2|8|3|2|1|0|2
93457289361783645984347|1|8|4|6|1|8|7|3|4|6
-------------------------------------------
93457381746507539182666|4|3|0|9|0|1|9|4|4|8
9345738174650753918266600|0|0|0|0|0|9|4|4|8

 */
