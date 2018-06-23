using System;

namespace _09_count_the_integers
{
    class CountTheIntegers
    {
        static void Main()
        {
            var totalNumbersReceived = 0;
            while (int.TryParse(Console.ReadLine(), out int number))
            {
                totalNumbersReceived++;
            }

            Console.WriteLine(totalNumbersReceived);
        }
    }
}