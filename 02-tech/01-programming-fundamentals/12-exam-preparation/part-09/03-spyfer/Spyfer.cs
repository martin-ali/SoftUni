using System;
using System.Linq;

namespace _03_spyfer
{
    class Spyfer
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < elements.Count; i++)
            {
                int next = i + 1;
                int prev = i - 1;

                var current = elements[i];
                var leftNeighbor = prev >= 0 ? elements[prev] : 0;
                var rightNeighbor = next < elements.Count ? elements[next] : 0;

                if (current == (leftNeighbor + rightNeighbor))
                {
                    if (next < elements.Count)
                    {
                        elements.RemoveAt(next);
                    }

                    if (prev >= 0)
                    {
                        elements.RemoveAt(prev);
                    }

                    i = 0;
                }
            }

            var result = string.Join(" ", elements);
            Console.WriteLine(result);
        }
    }
}
