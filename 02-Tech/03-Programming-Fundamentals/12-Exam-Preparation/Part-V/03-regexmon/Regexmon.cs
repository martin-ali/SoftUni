using System;
using System.Text.RegularExpressions;

namespace _03_regexmon
{
    class Regexmon
    {
        static void Main()
        {
            var text = Console.ReadLine();

            var bojomon = new Regex(@"[A-Za-z]+-[A-Za-z]+");
            var digimon = new Regex(@"[^A-Za-z-]+");

            var (current, next) = (digimon, bojomon);
            while (true)
            {
                var match = current.Match(text);

                if (match.Success)
                {
                    Console.WriteLine(match.Value);
                    text = text.Substring(match.Index);
                }
                else
                {
                    break;
                }

                (current, next) = (next, current);
            }
        }
    }
}
