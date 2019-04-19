using System;
using System.Linq;

namespace _06_reverse_and_exclude
{
    class ReverseAndExclude
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse);
            var integerToTestAgainst = int.Parse(Console.ReadLine());

            Func<int, bool> removeDivisible = x => x % integerToTestAgainst != 0;

            numbers = numbers
                        .Where(removeDivisible)
                        .Reverse();

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
