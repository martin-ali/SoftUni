using System;
using System.Collections.Generic;

namespace _01_phonebook
{
    class PhoneBook
    {
        static void Main()
        {
            var phonebook = new Dictionary<string, string>();
            var command = Console.ReadLine().Split(' ');
            while (command[0] != ("END"))
            {
                if (command[0] == "A")
                {
                    var name = command[1];
                    var number = command[2];
                    phonebook[name] = number;
                }
                else if (command[0] == "S")
                {
                    var name = command[1];
                    if (phonebook.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {phonebook[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }

                command = Console.ReadLine().Split(' ');
            }
        }
    }
}
