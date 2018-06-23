using System;
using System.Linq;

namespace _09_jump_around
{
    class JumpAround
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var step = arr.First();
            var position = 0;
            var sum = arr.First();
            while (true)
            {
                // Can move right
                if ((position + step) < arr.Length)
                {
                    position += step;
                    sum += arr[position];
                    step = arr[position];
                }
                // Can move left
                else if ((position - step) >= 0)
                {
                    position -= step;
                    sum += arr[position];
                    step = arr[position];
                }
                // Can't move anywhere
                else
                {
                    break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
/*

3 7 12 2 10
10 50 7 30 8 5
2 3 5 7 5 4 8 4

 */
