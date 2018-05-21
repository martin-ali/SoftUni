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

            var nBaseNumber = ConvertToBaseN(decimalNumber, toBase);

            Console.WriteLine(nBaseNumber);
        }

        private static string ConvertToBaseN(BigInteger decimalNumber, BigInteger toBase)
        {
            var nBaseNumber = "";
            while (decimalNumber > 0)
            {
                var remainder = decimalNumber % toBase;
                decimalNumber /= toBase;
                nBaseNumber = remainder + nBaseNumber;
            }

            return nBaseNumber;
        }
    }
}
