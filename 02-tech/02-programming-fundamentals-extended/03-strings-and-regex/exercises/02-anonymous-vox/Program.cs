using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02_anonymous_vox
{
    class Program
    {
        private static string encodedPlaceholderPattern = @"([?:A-Za-z]+)(.+)(?:\1)";

        // WHy can't I get non-capturing groups to work?? (?:)
        private static string placeholderPattern = @"{(.+?)}";

        private static string testInput = @"ASD___asdfffasd
Hello_mister,_Hello
Whatsup_ddd_sup
HeypalHey______how_ya_how_doin_how
a.....a
b!d!b
asdxxxxxasd
peshogoshopesho
asddvdasd";

        static void Main()
        {
            // var encodedText = testInput;
            // var placeholders = Regex.Matches("{first}{second}", placeholderPattern);

            var encodedText = Console.ReadLine();
            var placeholders = Regex.Matches(Console.ReadLine(), placeholderPattern);

            var currentPlaceholder = 0;
            var placeholderCount = placeholders.Count - 1;

            var replacedText = Regex.Replace(encodedText, encodedPlaceholderPattern, match =>
            {
                var placeholder = placeholders[Clamp(0, currentPlaceholder++, placeholderCount)].Groups[1];
                var tag = match.Groups[1];
                return $"{tag}{placeholder}{tag}";
            });

            Console.WriteLine(replacedText);
        }

        private static int Clamp(int min, int value, int max)
        {
            if (value > max)
            {
                return max;
            }
            else if (value < min)
            {
                return min;
            }
            else
            {
                return value;
            }
        }
    }
}