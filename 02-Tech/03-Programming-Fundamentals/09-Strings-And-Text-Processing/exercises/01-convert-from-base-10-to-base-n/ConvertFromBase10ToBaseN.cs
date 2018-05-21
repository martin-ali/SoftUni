using System;
using System.IO;
using System.Linq;
using System.Numerics;

namespace _01_convert_from_base_10_to_base_n
{
    class ConvertFromBase10ToBaseN
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();
            var toBase = input[0];
            var decimalNumber = input[1];

            var nBaseNumber = ConvertToBinary(decimalNumber, toBase);

            Console.WriteLine(nBaseNumber);
        }

        private static string ConvertToBinary(BigInteger decimalNumber, BigInteger toBase)
        {
            var binaryNumber = "";
            while (decimalNumber > 0)
            {
                var remainder = decimalNumber % toBase;
                decimalNumber /= toBase;
                binaryNumber = remainder + binaryNumber;
            }

            return binaryNumber;
        }
    }
}
