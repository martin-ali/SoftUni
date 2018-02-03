using System;

namespace Max_Number
{
    class Program
    {
        static void Main()
        {
            var numberOfInputs = int.Parse(Console.ReadLine());
            var biggestNumber = int.MinValue;

            for (int current = 0; current < numberOfInputs; current++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber > biggestNumber)
                {
                    biggestNumber = currentNumber;
                }
            }

            Console.WriteLine(biggestNumber);
        }
    }
}
