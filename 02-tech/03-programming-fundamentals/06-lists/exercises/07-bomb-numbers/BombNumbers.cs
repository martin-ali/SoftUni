using System;
using System.Linq;

namespace _07_bomb_numbers
{
    class BombNumbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').ToList();
            var arguments = Console.ReadLine().Split(' ').ToList();
            var bomb = arguments[0];
            var power = int.Parse(arguments[1]);

            for (int index = 0; index < numbers.Count; index++)
            {
                if (numbers[index] == bomb)
                {
                    var start = Math.Max(index - power, 0);
                    var end = Math.Min(index + power, numbers.Count - 1);

                    // Doable with RemoveRange()
                    for (int current = start; current <= end; current++)
                    {
                        numbers[current] = null;
                    }
                }
            }

            var sum = numbers.Where(x => x != null).Select(int.Parse).Sum();
            Console.WriteLine(sum);
        }
    }
}
/*

1 2 2 4 2 2 2 9
4 2

1 4 4 2 8 9 1
9 3

1 7 7 1 2 3
7 1

1 1 2 1 1 1 2 1 1 1
2 1

 */
