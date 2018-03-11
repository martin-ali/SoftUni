using System;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main()
        {
            var numberOfInputs = int.Parse(Console.ReadLine());

            var evenNumbersSum = 0;
            var oddNumbersSum = 0;

            for (int current = 0; current < numberOfInputs; current++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                if (current % 2 == 0)
                {
                    evenNumbersSum += currentNumber;
                }
                else
                {
                    oddNumbersSum += currentNumber;
                }
            }

            if (evenNumbersSum == oddNumbersSum)
            {
                Console.WriteLine($"Yes, sum = {evenNumbersSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(evenNumbersSum - oddNumbersSum)}");
            }
        }
    }
}
