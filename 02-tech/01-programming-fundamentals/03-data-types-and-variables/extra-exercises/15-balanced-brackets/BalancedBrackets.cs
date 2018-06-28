using System;

namespace _15_balanced_brackets
{
    class BalancedBrackets
    {
        static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());
            var bracketAreBalanced = true;
            var lastBracket = ")";

            for (int i = 0; i < numberOfLines; i++)
            {
                var currentLine = Console.ReadLine();
                if (currentLine != "(" && currentLine != ")")
                {
                    continue;
                }

                var currentBracket = currentLine;
                if (currentBracket == lastBracket)
                {
                    bracketAreBalanced = false;
                    break;
                }

                lastBracket = currentBracket;
            }

            var lastBracketIsWrong = lastBracket == "(";
            var bracketsState = bracketAreBalanced && lastBracketIsWrong == false ? "BALANCED" : "UNBALANCED";
            Console.WriteLine(bracketsState);
        }
    }
}
