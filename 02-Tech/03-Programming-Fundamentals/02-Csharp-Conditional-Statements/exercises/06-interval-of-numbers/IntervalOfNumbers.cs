using System;

namespace _06_interval_of_numbers
{
    class IntervalOfNumbers
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            var smallerNumber = Math.Min(firstNumber, secondNumber);
            var biggerNumber = Math.Max(firstNumber, secondNumber);

            for (int current = smallerNumber; current <= biggerNumber; current++)
            {
                Console.WriteLine(current);
            }
        }
    }
}
