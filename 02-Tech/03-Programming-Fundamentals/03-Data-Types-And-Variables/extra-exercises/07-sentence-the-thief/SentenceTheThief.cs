using System;
using System.Linq;

namespace _07_sentence_the_thief
{
    class SentenceTheThief
    {
        static void Main()
        {
            var numeralType = Console.ReadLine();
            var numberOfIds = int.Parse(Console.ReadLine());
            var ids = new long[numberOfIds];
            for (int index = 0; index < numberOfIds; index++)
            {
                ids[index] = long.Parse(Console.ReadLine());
            }

            var maxValue = 0L;
            switch (numeralType)
            {
                case "sbyte": maxValue = sbyte.MaxValue; break;
                case "int": maxValue = int.MaxValue; break;
                case "long": maxValue = long.MaxValue; break;
            }

            var thiefId = ids
                            .Where(id => id <= maxValue)
                            .Max();
            var sentenceDuration = thiefId > 0
                                    ? Math.Ceiling(thiefId / 127.0)
                                    : Math.Ceiling(thiefId / -128.0);

            var pluralizeIfNeeded = sentenceDuration > 1 ? "s" : "";
            Console.WriteLine($"Prisoner with id {thiefId} is sentenced to {sentenceDuration} year{pluralizeIfNeeded}");
        }
    }
}
