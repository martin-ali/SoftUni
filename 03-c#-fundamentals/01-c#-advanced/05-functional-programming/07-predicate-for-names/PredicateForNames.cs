using System;
using System.Linq;

namespace _07_predicate_for_names
{
    class PredicateForNames
    {
        static void Main()
        {
            Func<int, Func<string, bool>> lengthIsLessThanOrEqualTo = length => (name => name.Length <= length);

            var permittedLength = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            var filteredNames = names.Where(lengthIsLessThanOrEqualTo(permittedLength));
            foreach (var name in filteredNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
