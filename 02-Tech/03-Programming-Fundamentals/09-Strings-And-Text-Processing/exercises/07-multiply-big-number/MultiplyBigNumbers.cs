using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07_multiply_big_number
{
    class MultiplyBigNumbers
    {
        static void Main()
        {
            var number = Console.ReadLine().TrimStart('0');
            var multiplier = int.Parse(Console.ReadLine());

            string product = MultiplyBigIntegers(number, multiplier);
            Console.WriteLine(product);
        }

        private static string MultiplyBigIntegers(string number, int multiplier)
        {
            var product = "0";
            for (int i = 0; i < multiplier; i++)
            {
                product = SumBigIntegers(product, number);
            }

            return product;
        }

        private static string SumBigIntegers(string firstNumber, string secondNumber)
        {
            var length = Math.Max(firstNumber.Length, secondNumber.Length);

            var firstDigits = firstNumber.PadLeft(length, '0').Select(x => int.Parse(x.ToString())).ToArray();
            var secondDigits = secondNumber.PadLeft(length, '0').Select(x => int.Parse(x.ToString())).ToArray();
            var result = new Stack<int>();

            // Doable with Zip()
            var remainder = 0;
            for (long i = firstDigits.Length - 1; i >= 0; i--)
            {
                var sum = firstDigits[i] + secondDigits[i] + remainder;

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
