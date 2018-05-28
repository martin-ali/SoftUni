using System;
using System.Text.RegularExpressions;

namespace _01_extract_emails
{
    class ExtractEmails
    {
        // ([A-z0-9]+[.-_]?)@([A-z.-]+)
        private static readonly string EmailPattern = $"{UserPattern}@{HostPattern}";

        private static readonly string UserPattern = $"x";

        private static readonly string HostPattern = $"x";

        static void Main()
        {
            var text = Console.ReadLine();
            var emails = Regex.Matches(text, EmailPattern);
            foreach (Match email in emails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
