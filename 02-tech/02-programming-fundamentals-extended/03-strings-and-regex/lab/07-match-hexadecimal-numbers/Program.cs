using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07_match_hexadecimal_numbers
{
    class Program
    {
        static void Main()
        {
            var number = Console.ReadLine();

            var pattern = @"\b(0x)?[0-9A-F]+\b";
            var matchedNumbers = Regex.Matches(number, pattern).Cast<Match>().Select(match => match.Value.Trim());

            Console.WriteLine(String.Join(" ", matchedNumbers));
        }
    }
}
// 1F 0xG 0x1F G 0x4G 4G 0xAB 0xFG FG 0x10 10 AB FF