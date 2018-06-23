using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _06_match_phone_number
{
    class Program
    {
        static void Main()
        {
            var phones = Console.ReadLine();

            var pattern = @"(^| )\+359(-| )2\2[0-9]{3}\2[0-9]{4}\b";
            var matchedPhones = Regex.Matches(phones, pattern).Cast<Match>().Select(match => match.Value.Trim());

            Console.WriteLine(String.Join(", ", matchedPhones));
        }
    }
}
// +359 2 222 2222,359-2-222-2222, +359/2/222/2222, +359-2 222 2222 +359 2-222-2222, +359-2-222-222, +359-2-222-22222 +359-2-222-2222