using System;
using System.Linq;

namespace _13_trifunction
{
    class Trifunction
    {
        static void Main()
        {
            var length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            var name = GetFirstEqualOrLargerSumName(names, length);

            Console.WriteLine(name);
        }

        private static string GetFirstEqualOrLargerSumName(string[] names, int length)
        {
            Func<int, Func<string, bool>> sumIfCharsEquals = targetLength => word => word.Sum(x => x) >= targetLength;

            var name = names.FirstOrDefault(sumIfCharsEquals(length));

            return name;
        }
    }
}
