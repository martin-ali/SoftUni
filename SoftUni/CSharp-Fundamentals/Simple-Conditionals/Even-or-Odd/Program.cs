using System;

namespace Even_or_Odd
{
    class Program
    {
        static void Main()
        {
            var numberToCheck = double.Parse(Console.ReadLine());

            Console.WriteLine(numberToCheck % 2 == 0 ? "even" : "odd");
        }
    }
}
