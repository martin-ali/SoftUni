using System;

namespace _07_balanced_parentheses
{
    class BalancedParentheses
    {
        static void Main()
        {
            var inputParentheses = Console.ReadLine();

            var oldLength = inputParentheses.Length;
            var currentLength = 0;
            while (currentLength != oldLength)
            {
                inputParentheses = inputParentheses
                                    .Replace("()", "")
                                    .Replace("[]", "")
                                    .Replace("{}", "");

                oldLength = currentLength;
                currentLength = inputParentheses.Length;
            }

            var parenthesesAreBalanced = inputParentheses.Length == 0 ? "YES" : "NO";
            Console.WriteLine(parenthesesAreBalanced);
        }
    }
}
