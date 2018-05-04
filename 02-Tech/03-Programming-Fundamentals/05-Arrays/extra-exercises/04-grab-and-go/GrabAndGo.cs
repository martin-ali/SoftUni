using System;
using System.Linq;

namespace _04_grab_and_go
{
    class GrabAndGo
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            var elementToFind = int.Parse(Console.ReadLine());

            var indexOfElement = arr.LastIndexOf(elementToFind);

            var elementIsFound = (indexOfElement >= 0);
            if (elementIsFound)
            {
                var previousElementsSum = arr.Take(indexOfElement).Sum();
                Console.WriteLine(previousElementsSum);
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }
        }
    }
}
/*

10 20 30 40 20 30 40
20

1 3 5 7 12 2 3 5 12
3

1 2 3 4 5 6 7 8 9 10
20

 */
