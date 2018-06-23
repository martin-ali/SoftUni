using System;
using System.Linq;

namespace _11_equal_sums
{
    class EqualSums
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var result = "no";
            for (int index = 0; index < elements.Length; index++)
            {
                var leftSum = elements.Take(index).Sum();
                var rightSum = elements.Skip(index + 1).Sum();

                if (leftSum == rightSum)
                {
                    result = index.ToString();
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
/*

1 2 3 3
1 2
1
1 2 3
10 5 5 99 3 4 2 5 1 1 4

 */
