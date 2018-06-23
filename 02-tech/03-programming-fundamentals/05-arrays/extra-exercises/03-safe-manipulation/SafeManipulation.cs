using System;
using System.Collections.Generic;

namespace _03_safe_manipulation
{
    class SafeManipulation
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split(' ');

            var command = Console.ReadLine().Split(' ');
            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "Distinct":
                        {
                            arr = Distinct(arr);
                            break;
                        }
                    case "Reverse":
                        {
                            Array.Reverse(arr);
                            break;
                        }
                    case "Replace":
                        {
                            var index = int.Parse(command[1]);
                            if (index < 0 || index >= arr.Length)
                            {
                                goto default;
                            }

                            var newItem = command[2];
                            arr[index] = newItem;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                }

                command = Console.ReadLine().Split(' ');
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
Distinct
Reverse
Replace 7 Hello
Replace -5 Hello
Replace 0 Hello
END

Alpha Bravo Charlie Delta Echo Foxtrot
Distinct
Reverse
Replace 0 Charlie
Reverse
Replace 1 Charlie
Distinct
Replace 4 Charlie
END

 */
