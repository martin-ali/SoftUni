using System;
using System.Collections.Generic;

namespace _01_reverse_numbers_with_a_stack
{
    class ReverseNumbersWithStack
    {
        static void Main()
        {
            var items = new Stack<string>((Console.ReadLine().Split(' ')));

            foreach (var item in items)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
