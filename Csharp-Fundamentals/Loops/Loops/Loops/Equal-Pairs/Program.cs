using System;

namespace Equal_Pairs
{
    class Program
    {
        static void Main()
        {
            var numberOfInputs = int.Parse(Console.ReadLine());

            var intialNumber1 = int.Parse(Console.ReadLine());
            var initialNumber2 = int.Parse(Console.ReadLine());

            var lastSum = intialNumber1 + initialNumber2;
            var biggestDifference = int.MinValue;
            var allPairsAreEqual = true;

            for (int current = 1; current < numberOfInputs; current++)
            {
                var firstNumber = int.Parse(Console.ReadLine());
                var secondNumber = int.Parse(Console.ReadLine());
                var currentSum = firstNumber + secondNumber;

                if (currentSum != lastSum)
                {
                    allPairsAreEqual = false;
                }

                if (Math.Abs(currentSum - lastSum) > biggestDifference)
                {
                    biggestDifference = Math.Abs(currentSum - lastSum);
                }

                lastSum = currentSum;
            }

            if (allPairsAreEqual)
            {
                Console.WriteLine($"Yes, value={lastSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={biggestDifference}");
            }
        }
    }
}
