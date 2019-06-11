using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_custom_min_function
{
    class CustomMinFunction
    {
        static void Main()
        {
            Func<IEnumerable<int>, int> findMin = items => items.Min();

            var numbers = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse);

            var minNumber = findMin(numbers);
            Console.WriteLine(minNumber);
        }
    }
}
