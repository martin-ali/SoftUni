using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_custom_min_function
{
    class CustomMinFunction
    {
        static void Main()
        {
            Func<IEnumerable<int>, int> findSmallest = nums => nums.Min();

            var numbers = Console.ReadLine()
                        .Split()
                        .Select(int.Parse);

            var smallest = findSmallest(numbers);
            Console.WriteLine(smallest);
        }
    }
}
