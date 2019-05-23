using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_even_times
{
    class EvenTimes
    {
        static void Main()
        {
            var numbersCount = int.Parse(Console.ReadLine());

            var occurrencesByNumber = new Dictionary<int, int>();
            for (int i = 0; i < numbersCount; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (occurrencesByNumber.ContainsKey(number) == false)
                {
                    occurrencesByNumber[number] = 0;
                }

                occurrencesByNumber[number]++;
            }

            var numberWithEvenOccurrences = occurrencesByNumber.Single(x => x.Value % 2 == 0);
            Console.WriteLine(numberWithEvenOccurrences.Key);
        }
    }
}
