using System;

namespace Three_Equal_Numbers
{
    class Program
    {
        static void Main()
        {
            var firstNumber = double.Parse(Console.ReadLine());
            var secondNumber = double.Parse(Console.ReadLine());
            var thirdNumber = double.Parse(Console.ReadLine());

            var areAllNumbersEqual = firstNumber == secondNumber && secondNumber == thirdNumber;
            Console.WriteLine(areAllNumbersEqual ? "yes" : "no");
        }
    }
}
