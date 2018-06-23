using System;

namespace _13_integer_to_hex_and_binary
{
    class IntegerToHexAndBinary
    {
        // Could be done with Convert.ToString(), but that would not be much fun, now would it?
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var numberInHex = ConvertToHex(number);
            var numberInBin = ConvertToBin(number);
            Console.WriteLine(numberInHex);
            Console.WriteLine(numberInBin);
        }

        private static string ConvertToHex(int number)
        {
            return ConvertFromDecTo(number, 16);
        }

        private static string ConvertToBin(int number)
        {
            return ConvertFromDecTo(number, 2);
        }

        private static string ConvertFromDecTo(int number, int toBase)
        {
            char[] convertSystem = "0123456789ABCDEF".ToCharArray();
            int lastResult = number;
            var numberInHex = string.Empty;

            while (lastResult > 0)
            {
                var currentResult = (double)lastResult / toBase;

                lastResult = (int)Math.Floor(currentResult);
                var remainder = convertSystem[(int)((currentResult % 1) * toBase)];

                numberInHex = $"{remainder}{numberInHex}";
            }

            return numberInHex;
        }
    }
}
