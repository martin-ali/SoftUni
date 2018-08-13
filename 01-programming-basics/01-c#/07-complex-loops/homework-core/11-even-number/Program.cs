using System;

namespace _11_even_number
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                var number = double.Parse(Console.ReadLine());
                bool numberIsEven = number % 2 == 0;
                if (numberIsEven)
                {
                    Console.WriteLine($"Even number entered: {number}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }
    }
}
