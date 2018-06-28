using System;
using System.Collections.Generic;

namespace _01_phonebook
{
    class PhoneBook
    {
        static void Main()
        {
            var phonebook = new Dictionary<string, string>();
            var parameters = Console.ReadLine().Split(' ');
            while (parameters[0] != "END")
            {
                if (parameters[0] == "A")
                {
                    var name = parameters[1];
                    var number = parameters[2];
                    phonebook[name] = number;
                }
                else if (parameters[0] == "S")
                {
                    var name = parameters[1];
                    if (phonebook.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {phonebook[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }

                parameters = Console.ReadLine().Split(' ');
            }
        }
    }
}
