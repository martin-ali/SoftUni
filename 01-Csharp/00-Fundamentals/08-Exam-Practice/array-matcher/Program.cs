using System;
using System.Linq;
using System.Collections.Generic;

namespace array_matcher
{
    class Program
    {
        static void Main()
        {

            string[] data = Console.ReadLine().Split('\\');
            var firstArray = data[0].ToCharArray();
            var secondArray = data[1].ToCharArray();
            var command = data[2].ToLower();

            var execute = new Dictionary<string, Func<char[], char[], char[]>>();
            execute["join"] = Join;
            execute["left exclude"] = LeftExclude;
            execute["right exclude"] = RightExclude;

            var result = Sort(execute[command](firstArray, secondArray));

            Console.WriteLine(result);
        }

        private static G[] Sort<G>(G[] first)
        {
            var items = first.ToList();
            items.Sort();
            return items.ToArray();
        }

        private static G[] queryArrays<G>(G[] first, G[] second, Func<G[], G[], int, bool> ex)
        {
            var joinedArrays = new List<G>();

            for (int current = 0; current < first.Length; current++)
            {
                if (ex(second, first, current))
                {
                    joinedArrays.Add(first[current]);
                }
            }

            return joinedArrays.ToArray();
        }

        private static G[] Join<G>(G[] first, G[] second)
        {
            return queryArrays(first, second, (x, y, index) => x.Contains(y[index]));
        }

        private static G[] LeftExclude<G>(G[] first, G[] second)
        {
            return queryArrays(second, first, (x, y, index) => x.Contains(y[index]) == false);
        }

        // LOL
        private static G[] RightExclude<G>(G[] first, G[] second)
        {
            return queryArrays(first, second, (x, y, index) => x.Contains(y[index]) == false);
        }
    }
}
