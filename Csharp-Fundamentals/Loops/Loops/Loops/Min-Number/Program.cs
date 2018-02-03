using System;

namespace Min_Number
{
    class Program
    {
        static void Main()
        {
            var numberOfInputs = int.Parse(Console.ReadLine());
            var smallestNumber = int.MaxValue;

            for (int current = 0; current < numberOfInputs; current++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber < smallestNumber)
                {
                    smallestNumber = currentNumber;
                }
            }

            Console.WriteLine(smallestNumber);
        }
    }
}
