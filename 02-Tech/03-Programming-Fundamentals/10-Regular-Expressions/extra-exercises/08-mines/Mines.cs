using System;
using System.Text.RegularExpressions;

namespace _08_mines
{
    class Mines
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var minePattern = new Regex("<..>");
            var mineMatches = minePattern.Matches(input);
            foreach (Match mine in mineMatches)
            {
                var power = Math.Abs(mine.Value[1] - mine.Value[2]);
                var startIndex = Clamp(0, mine.Index - power, input.Length);
                var endIndex = Clamp(0, mine.Index + 4 + power, input.Length);
                var characterCount = endIndex - startIndex;

                input = input.Remove(startIndex, characterCount);
                input = input.Insert(startIndex, new string('_', characterCount));
            }

            Console.WriteLine(input);
        }

        private static int Clamp(int min, int value, int max)
        {
            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
        }
    }
}
/*

bewareOf<AF>TheMines

TwoMin<ag>esWillBeHe<HH>reMuchDangerous

aaaaa<AF>

Two<Min<ag>esWillBeHe<HH>reMuchDangerous

 */
