using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01_trainegram
{
    class Program
    {
        private static string locomotivePattern = @"<\[[^a-zA-Z\d]*?\]\.";

        private static string wagonPattern = @"\.\[[A-Za-z\d]*?\]\.";

        private static string trainPattern = $"^({locomotivePattern})({wagonPattern})*$";

        private static string testInput = @"<[/**]..[asd]..[3dx]..[]..[].
<>
Traincode!";

        static void Main()
        {
            var input = ReadInput();
            foreach (var line in input)
            {
                if (Regex.IsMatch(line, trainPattern))
                {
                    Console.WriteLine(line);
                }
            }
        }

        private static IEnumerable<String> ReadInput()
        {
            var lines = new List<string>();

            var line = Console.ReadLine();
            while (line != "Traincode!")
            {
                lines.Add(line);
                line = Console.ReadLine();
            }

            return lines;
        }
    }
}
// https://regex101.com/r/tGgN5l/1

// <[{]..[7]..[]..[]..[C2I43].
// <[(_#/}$)$]..[GO5A]..[G5]..[3W4].
// <[^]..[54]..[S].
// <[{]..[7]..[]..[]..[C2I43].
// <[(_#/}$)$]..[GO5A]..[G5]..[3W4].
// <[^]..[54]..[S].
// <[@].
// <[)$-{,]..[PB1N]..[R757G].
// <[]..[]..[10]..[223F]..[GBM4].
// <[!]..[]
// <[)_]..[3N]..[TS]..[0NS58].
// Trainegram!