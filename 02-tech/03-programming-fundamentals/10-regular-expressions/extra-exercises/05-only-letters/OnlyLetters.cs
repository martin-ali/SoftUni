using System;
using System.Text.RegularExpressions;

namespace _05_only_letters
{
    class OnlyLetters
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var replacedString = Regex.Replace(input, @"(\d+)([A-Za-z])",
                                        x => string.Format("{0}{0}", x.Groups[2].Value));
            Console.WriteLine(replacedString);
        }
    }
}
/*

ChangeThis12andThis56k

1Beware72ForThe4End88888

 */
