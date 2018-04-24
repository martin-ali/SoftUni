using System;

namespace _09_count_the_integers
{
    class CountTheIntegers
    {
        static void Main()
        {
            var totalNumbersReceived = 0;
            while (true)
            {
                var number = 0;
                var input = Console.ReadLine();

                if (int.TryParse(input, out number) == false)
                {
                    break;
                }

                totalNumbersReceived++;
            }

            Console.WriteLine(totalNumbersReceived);
        }
    }
}