using System;
using System.Linq;

namespace _07_predicate_for_names
{
    class PredicateForNames
    {
        static void Main()
        {
            var lengthThreshold = int.Parse(Console.ReadLine());
            Func<string, bool> itemLengthIsBelowThreshold = x => x.Length <= lengthThreshold;

            var names = Console.ReadLine()
                                .Split()
                                .Where(itemLengthIsBelowThreshold);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
