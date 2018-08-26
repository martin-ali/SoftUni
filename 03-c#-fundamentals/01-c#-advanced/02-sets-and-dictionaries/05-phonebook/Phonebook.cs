using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_phonebook
{
    class Phonebook
    {
        static void Main()
        {
            var phonebook = new Dictionary<string, string>();

            var command = Console.ReadLine();
            while (command != "stop" && command != "search")
            {
                var contactInfo = Console.ReadLine().Split("-");
                var name = contactInfo[0];
                var phone = contactInfo[1];

                phonebook[name] = phone;

                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (command != "stop")
            {
                if (phonebook.ContainsKey(command))
                {
                    Console.WriteLine($"{command} -> {phonebook[command]}");
                }
                else
                {
                    Console.WriteLine($"Contact {command} does not exist.");
                }

                command = Console.ReadLine();
            }
        }
    }
}
