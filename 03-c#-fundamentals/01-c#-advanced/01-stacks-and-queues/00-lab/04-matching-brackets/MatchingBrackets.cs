using System;
using System.Collections.Generic;

namespace _04_matching_brackets
{
    class MatchingBrackets
    {
        static void Main()
        {
            var expression = Console.ReadLine();

            var subexpressionIndices = new Stack<int>();
            for (int index = 0; index < expression.Length; index++)
            {
                if (expression[index] == '(')
                {
                    subexpressionIndices.Push(index);
                }
                else if (expression[index] == ')')
                {
                    var start = subexpressionIndices.Pop();
                    var count = index - start + 1;
                    Console.WriteLine(expression.Substring(start, count));
                }
            }
        }
    }
}
/*

1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5

(2 + 3) - (2 + 3)

*/
