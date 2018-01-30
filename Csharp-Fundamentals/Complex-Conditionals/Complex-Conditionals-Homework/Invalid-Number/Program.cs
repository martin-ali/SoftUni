using System;

namespace Invalid_Number
{
    class Program
    {
        static void Main()
        {
            var number = double.Parse(Console.ReadLine());

            var numberIsInRange = number >= 100 && number <= 200;
            if (number != 0 && numberIsInRange == false)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
