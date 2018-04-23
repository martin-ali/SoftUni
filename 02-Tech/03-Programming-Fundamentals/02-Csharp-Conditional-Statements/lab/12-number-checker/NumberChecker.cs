using System;

namespace _12_number_checker
{
    class NumberChecker
    {
        static void Main()
        {
            try
            {
                double number = double.Parse(Console.ReadLine());
                Console.WriteLine("It is a number.");
            }
            catch (System.Exception)
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
