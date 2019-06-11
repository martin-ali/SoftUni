using System;
using System.Linq;

namespace _02_knights_of_honor
{
    class KnightsOfHonor
    {
        static void Main()
        {
            Action<string> print = item => Console.WriteLine(item);
            Func<string, string> prefixSir = name => $"Sir {name}";

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(prefixSir)
                .ToList()
                .ForEach(print);
        }
    }
}
