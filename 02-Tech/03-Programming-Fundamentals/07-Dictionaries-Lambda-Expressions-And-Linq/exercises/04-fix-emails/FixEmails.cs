using System;
using System.Globalization;

namespace _04_fix_emails
{
    class FixEmails
    {
        static void Main()
        {
            var command = Console.ReadLine();
            while (command != "stop")
            {
                var name = command;
                var email = Console.ReadLine();

                string emailLowercase = email.ToLower();
                if (emailLowercase.EndsWith("us") == false
                    && emailLowercase.EndsWith("uk") == false)
                {
                    Console.WriteLine($"{name} -> {email}");
                }

                command = Console.ReadLine();
            }
        }
    }
}
/*

Ivan
ivanivan@abv.bg
Petar Ivanov
petartudjarov@abv.bg
Mike Tyson
myke@gmail.us
stop

 */
