using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_manipulate_array
{
    class ManipulateArray
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split(' ');
            var commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                var command = Console.ReadLine().Split(' ');

                switch (command[0].ToLower())
                {
                    case "distinct":
                        {
                            arr = Distinct(arr);
                        }

                        break;
                    case "reverse":
                        {
                            Array.Reverse(arr);
                        }

                        break;
                    case "replace":
                        {
                            var index = int.Parse(command[1]);
                            var newItem = command[2];
                            arr[index] = newItem;
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(", ", arr));
        }

        private static string[] Distinct(string[] arr)
        {
            var distinctElements = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (distinctElements.Contains(arr[i]) == false)
                {
                    distinctElements.Add(arr[i]);
                }
            }

            return distinctElements.ToArray();
        }
    }
}
/*

one one one two three four five
3
Distinct
Reverse
Replace 2 Hello

Alpha Bravo Charlie Delta Echo Foxtrot
6
Distinct
Reverse
Replace 1 Charlie
Distinct
Reverse
Replace 2 Charlie

 */
