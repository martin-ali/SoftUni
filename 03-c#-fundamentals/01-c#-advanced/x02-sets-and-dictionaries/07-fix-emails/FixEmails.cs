using System;
using System.Collections.Generic;

namespace _07_fix_emails
{
    class FixEmails
    {
        static void Main()
        {
            var emailsByName = new Dictionary<string, string>();

            var command = Console.ReadLine();
            while (command != "stop")
            {
                var name = command;
                var email = Console.ReadLine();

                if (email.EndsWith("uk", StringComparison.InvariantCultureIgnoreCase)
                    || email.EndsWith("us", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                emailsByName[name] = email;

                command = Console.ReadLine();
            }

            foreach (var nameAndEmail in emailsByName)
            {
                Console.WriteLine($"{nameAndEmail.Key} -> {nameAndEmail.Value}");
            }
        }
    }
}
