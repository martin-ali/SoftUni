using System;

namespace _11_odd_number
{
    class OddNumber
    {
        static void Main()
        {
            while (true)
            {
                var number = int.Parse(Console.ReadLine());
                if (number % 2 != 0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(number)}");
                    break;
                }
                else
                {
                    Console.WriteLine("Please write an odd number.");
                }
            }
        }
    }
}
