using System;

namespace _04_variable_in_hexadecimal_format
{
    class VariableInHexadecimalFormat
    {
        static void Main()
        {
            var numberInHex = Console.ReadLine();
            var numberInDec = Convert.ToInt32(numberInHex, 16);
            Console.WriteLine(numberInDec);
        }
    }
}
