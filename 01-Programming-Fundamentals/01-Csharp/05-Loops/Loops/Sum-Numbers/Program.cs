using System;

namespace Sum_Numbers
{
    class Program
    {
        static void Main()
        {
            var numberOfInputs = int.Parse(Console.ReadLine());
            var sum = 0;

            for (int current = 0; current < numberOfInputs; current++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber;
            }

            Console.WriteLine(sum);
        }
    }
}
