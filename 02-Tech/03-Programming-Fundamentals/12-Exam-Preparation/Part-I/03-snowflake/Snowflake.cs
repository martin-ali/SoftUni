using System;
using System.Text.RegularExpressions;

namespace _03_snowflake
{
    class Snowflake
    {
        private static string SurfacePattern = @"[^A-Za-z0-9]+";

        private static string MantlePattern = @"[0-9_]+";

        private static string CorePattern = @"[A-Za-z]+";

        static void Main()
        {
            var surface = new Regex($"^{SurfacePattern}$");
            var mantle = new Regex($"^{MantlePattern}$");
            var core = new Regex($"^{CorePattern}$");
            var midsection = new Regex($"^{SurfacePattern}{MantlePattern}({CorePattern}){MantlePattern}{SurfacePattern}$");

            var topIsValid = surface.IsMatch(Console.ReadLine())
                                && mantle.IsMatch(Console.ReadLine());

            var midsectionMatch = midsection.Match(Console.ReadLine());
            var middleIsValid = midsectionMatch.Success;
            var coreLength = midsectionMatch.Groups[1].Length;

            var bottomIsValid = mantle.IsMatch(Console.ReadLine())
                                && surface.IsMatch(Console.ReadLine());

            if (topIsValid && middleIsValid && bottomIsValid)
            {
                Console.WriteLine("Valid");
                Console.WriteLine(coreLength);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
