using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_applied_arithmetics
{
    class AppliedArithmetics
    {
        static void Main()
        {
            Func<int, int> addOne = x => x + 1;
            Func<int, int> subtractOne = x => x - 1;
            Func<int, int> multiplyByTwo = x => x * 2;
            var numbers = Console.ReadLine().Split().Select(int.Parse);

            var command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = numbers.Select(addOne);
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(subtractOne);
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(multiplyByTwo);
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(' ', numbers));
                }

                command = Console.ReadLine();
            }
        }
    }
}
