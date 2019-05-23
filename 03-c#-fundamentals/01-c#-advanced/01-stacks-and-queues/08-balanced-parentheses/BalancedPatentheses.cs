using System;
using System.Collections.Generic;

namespace _08_balanced_parentheses
{
    class BalancedPatentheses
    {
        static void Main()
        {
            var parentheses = Console.ReadLine().ToCharArray();
            var parenthesesHistory = new Stack<char>();

            var parenthesesAreBalanced = true;
            foreach (var parenthesis in parentheses)
            {
                if (parenthesis == '('
                    || parenthesis == '['
                    || parenthesis == '{')
                {
                    parenthesesHistory.Push(parenthesis);
                }
                else if (parenthesis == ')'
                        && parenthesesHistory.Count > 0
                        && parenthesesHistory.Peek() == '(')
                {
                    parenthesesHistory.Pop();
                }
                else if (parenthesis == ']'
                        && parenthesesHistory.Count > 0
                        && parenthesesHistory.Peek() == '[')
                {
                    parenthesesHistory.Pop();
                }
                else if (parenthesis == '}'
                        && parenthesesHistory.Count > 0
                        && parenthesesHistory.Peek() == '{')
                {
                    parenthesesHistory.Pop();
                }
                else
                {
                    parenthesesAreBalanced = false;
                    break;
                }
            }

            Console.WriteLine(parenthesesAreBalanced ? "YES" : "NO");
        }
    }
}
// )()()()()()(