using System;

namespace Left_And_Right_Sum
{
    class Program
    {
        static void Main()
        {
            var numberOfInputs = int.Parse(Console.ReadLine());

            var leftSum = 0;
            var rightSum = 0;

            for (int current = 0; current < numberOfInputs; current++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                leftSum += currentNumber;
            }

            for (int current = 0; current < numberOfInputs; current++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                rightSum += currentNumber;
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftSum - rightSum)}");
            }
        }
    }
}
