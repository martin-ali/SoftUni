using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05_key_replacer
{
    class KeyReplacer
    {
        static void Main()
        {
            var keys = Regex.Split(Console.ReadLine(), @"[|</].*[|</]");
            var pattern = new Regex($"{keys.First()}(.*?){keys.Last()}");
            var text = Console.ReadLine();

            var matches = pattern.Matches(text).Select(m => m.Groups[1].Value);
            var message = string.Concat(matches);
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Empty result");
            }
        }
    }
}
/*

start<213asfaas|end
saaastarthelloendsdarstartFromTheOtherenddvsefdsfstartSideend

A|safafasfsadf|Csddsd|B
AB12345BABAkjahdkjdhdghgdjhgB

A|safafasfsadf|B
NoMEssageABhereYeyAB

 */
