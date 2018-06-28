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
            var input = Console.ReadLine().Split(' ');
            var number = BigInteger.Parse(input[1]);
            var toBase = int.Parse(input[0]);

            var nBaseNumber = ConvertBase10ToBaseN(number, toBase);

            Console.WriteLine(nBaseNumber);
        }

        private static string ConvertBase10ToBaseN(BigInteger decimalNumber, int toBase)
        {
            var BaseNNumber = "";
            while (decimalNumber > 0)
            {
                var remainder = decimalNumber % toBase;
                decimalNumber /= toBase;
                BaseNNumber = remainder + BaseNNumber;
            }

            return BaseNNumber;
        }
    }
}
