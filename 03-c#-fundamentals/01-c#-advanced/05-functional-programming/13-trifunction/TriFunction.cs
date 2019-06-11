using System;
using System.Linq;

namespace _13_trifunction
{
    class TriFunction
    {
        static void Main()
        {
            var lengthNeeded = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isBiggerThanOrEqual = (name, length) => name.Sum(c => (int)c) >= length;
            var firstBigName = names.FirstOrDefault(name => isBiggerThanOrEqual(name, lengthNeeded));

            Console.WriteLine(firstBigName);
        }
    }
}
