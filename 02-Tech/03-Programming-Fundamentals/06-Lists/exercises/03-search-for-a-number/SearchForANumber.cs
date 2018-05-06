using System;
using System.Linq;

namespace _03_search_for_a_number
{
    class SearchForANumber
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse);
            var arguments = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var numberFound = numbers
                                .Take(arguments[0])
                                .Skip(arguments[1])
                                .Contains(arguments[2]);

            Console.WriteLine(numberFound ? "YES!" : "NO!");
        }
    }
}
