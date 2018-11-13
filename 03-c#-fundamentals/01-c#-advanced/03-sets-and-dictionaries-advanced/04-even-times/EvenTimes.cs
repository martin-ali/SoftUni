using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_even_times
{
    class EvenTimes
    {
        static void Main()
        {
            var occurrenceCountByNumber = new Dictionary<int, int>();
            var numberCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCount; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (occurrenceCountByNumber.ContainsKey(number) == false)
                {
                    occurrenceCountByNumber[number] = 0;
                }

                occurrenceCountByNumber[number]++;
            }

            var numberWithEvenOccurrences = occurrenceCountByNumber.Single(n => n.Value % 2 == 0).Key;
            Console.WriteLine(numberWithEvenOccurrences);
        }
    }
}
