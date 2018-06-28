using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05_fix_emails
{
    class FixEmails
    {
        static void Main()
        {
            var lines = File.ReadAllLines("input.txt").ToList();
            var sanitizedLines = new List<string>();

            for (int i = 0; lines[i] != "stop"; i += 2)
            {
                var name = lines[i];
                var email = lines[i + 1];

                var emailIsValid = email.EndsWith("uk") == false
                                && email.EndsWith("us") == false;
                if (emailIsValid)
                {
                    sanitizedLines.Add($"{name} -> {email}");
                }
            }

            File.WriteAllLines("output.txt", sanitizedLines);
        }
    }
}
