using System;
using System.Linq;

namespace _02_knights_of_honor
{
    class KnightsOfHonor
    {
        static void Main()
        {
            Func<string, string> prependTitle = name => $"Sir {name}";
            Action<object> print = x => Console.WriteLine(x);

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(prependTitle)
                .ToList()
                .ForEach(print);
        }
    }
}
