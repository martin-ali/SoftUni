using System;
using System.Linq;

namespace _06_catch_the_thief
{
    class CatchTheThief
    {
        static void Main()
        {
            var numeralType = Console.ReadLine();
            int numberOfIds = int.Parse(Console.ReadLine());

            var ids = new long[numberOfIds];
            for (int current = 0; current < numberOfIds; current++)
            {
                ids[current] = long.Parse(Console.ReadLine());
            }

            long maxValue = 0;
            switch (numeralType)
            {
                case "sbyte": maxValue = sbyte.MaxValue; break;
                case "int": maxValue = int.MaxValue; break;
                case "long": maxValue = long.MaxValue; break;
            }

            var thiefId = ids
                            .Where(id => id <= maxValue)
                            .Max();

            Console.WriteLine(thiefId);
        }
    }
}
