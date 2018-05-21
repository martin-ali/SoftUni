using System;
using System.Numerics;

namespace _02_convert_from_base_n_to_base_10
{
    class ConvertFromBaseNToBase10
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var number = input[1];
            var fromBase = int.Parse(input[0]);

            var nBaseNumber = ConvertBaseNToDecimal(number, fromBase);

            Console.WriteLine(nBaseNumber);
        }

        private static BigInteger ConvertBaseNToDecimal(string number, int fromBase)
        {
            BigInteger Base10Number = 0;
            var power = number.Length - 1;
            for (int i = 0; i < number.Length; i++)
            {
                int digit = ((int)number[i] - 48);
                BigInteger current = digit * BigInteger.Pow(fromBase, power--);
                Base10Number += current;
            }

            return Base10Number;
        }
    }
}

/*

7 13
3 12201
5 443
4 33220
9 4704
2 1011

 */
