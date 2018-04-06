using System;
using System.Text.RegularExpressions;

namespace _02_anonymous_vox
{
    class Program
    {
        private static string encodedPlaceholderPattern = @"([?:A-Za-z]+)(.+)(?:\1)";

        private static string placeholderPattern = @"(?:{).+?(?:})";

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
            // var encodedText = Console.ReadLine();
            var encodedText = testInput;
            // var placeholders = Console.ReadLine();
            var placeholders = Regex.Matches("{first}{second}", placeholderPattern);
            var index = 0;
            var len = placeholders.Count - 1;

            var newText = Regex.Replace(encodedText, encodedPlaceholderPattern, $"$1{placeholders[Clamp(0, index++, len)]}$1");

            Console.WriteLine(newText);

        }

        private static int Clamp(int min, int value, int max)
        {
            if (value > max) return max;
            else if (value < min) return min;
            else return value;
        }
    }
}

// ASD___asdfffasd
// Hello_mister,_Hello
// Whatsup_ddd_sup
// HeypalHey______how_ya_how_doin_how
// a.....a
// b!d!b
// asdxxxxxasd
// peshogoshopesho
// asddvdasd