using System;
using System.Collections.Generic;

namespace _17_debugging_be_positive
{
    class DebuggingBePositive   // Yeah, sure
    {
        public static void Main()
        {
            int sequencesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < sequencesCount; i++)
            {
                string[] input = Console.ReadLine().Trim().Split(' ');
                var numbers = new List<int>();

                for (int j = 0; j < input.Length; j++)
                {
                    if (!input[j].Equals(string.Empty))
                    {
                        int num = int.Parse(input[j]);
                        numbers.Add(num);
                    }
                }

                bool found = false;

                for (int j = 0; j < numbers.Count; j++)
                {
                    int currentNum = numbers[j];

                    if (currentNum >= 0)
                    {
                        if (found)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(currentNum);

                        found = true;
                    }
                    else
                    {
                        int nextIndex = j + 1;
                        if (nextIndex < numbers.Count)
                        {
                            currentNum += numbers[nextIndex];
                        }

                        if (currentNum >= 0)
                        {
                            if (found)
                            {
                                Console.Write(" ");
                            }

                            Console.Write(currentNum);

                            found = true;
                        }

                        j++;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("(empty)");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
/*

1
0 -2 2 -2 3

3
3 -4 5 2 123
-1 -1 3 4
-2 1

 */
