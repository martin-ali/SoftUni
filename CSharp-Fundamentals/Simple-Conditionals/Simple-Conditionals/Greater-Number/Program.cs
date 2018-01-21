using System;

namespace Greater_Number
{
    class Program
    {
        static void Main()
        {
            var firstNumber = double.Parse(Console.ReadLine());
            var secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Max(firstNumber, secondNumber));
        }
    }
}
