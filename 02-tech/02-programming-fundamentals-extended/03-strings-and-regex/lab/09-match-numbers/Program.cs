using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09_match_numbers
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine();

            // Lookbehind -> (?<=\s)
            var pattern = @"(^|\s)-?\d+(\.\d+)?(?=$|\s)";
            var matchedNumbers = Regex.Matches(numbers, pattern).Cast<Match>().Select(match => match.Value.Trim());

            Console.WriteLine(String.Join(" ", matchedNumbers));
        }
    }
}
// 1 -1 1s 123 s-s -123 _55_ _f 123.456 -123.456 s-1.1 s2 -1- zs-2 s-3.5
