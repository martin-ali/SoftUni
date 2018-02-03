using System;
using System.Collections.Generic;

namespace Half_Sum_Element
{
    class Program
    {
        static void Main()
        {
            var numberOfInputs = int.Parse(Console.ReadLine());

            var numbers = new List<int>();
            var sum = 0;
            var itemIsFound = false;
            var biggestNumber = int.MinValue;

            for (int current = 0; current < numberOfInputs; current++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                numbers.Add(currentNumber);
                sum += currentNumber;

                if (currentNumber > biggestNumber)
                {
                    biggestNumber = currentNumber;
                }
            }

            foreach (int number in numbers)
            {
                var numberIsEqualToSumOfRest = number == (sum - number);
                if (numberIsEqualToSumOfRest)
                {
                    Console.WriteLine($"Yes, sum = {number}");
                    itemIsFound = true;
                }
            }

            if (itemIsFound == false)
            {
                Console.WriteLine($"No, diff = {Math.Abs((sum - biggestNumber) - biggestNumber)}");
            }
        }
    }
}
