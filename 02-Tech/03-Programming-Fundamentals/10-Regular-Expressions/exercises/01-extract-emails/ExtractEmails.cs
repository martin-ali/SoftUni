using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _01_extract_emails
{
    class ExtractEmails
    {
        private static readonly string userPattern = @" [a-z0-9]+([-_.][a-z0-9]+)*";

        private static readonly string hostPattern = @"[a-z0-9-]+(\.[a-z0-9-]+)+";

        private static readonly string validEmailPattern = $"{userPattern}@{hostPattern}";

        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("test.txt"));
            #endif

            var text = Console.ReadLine();
            var validEmails = Regex.Matches(text, validEmailPattern);
            foreach (Match email in validEmails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
