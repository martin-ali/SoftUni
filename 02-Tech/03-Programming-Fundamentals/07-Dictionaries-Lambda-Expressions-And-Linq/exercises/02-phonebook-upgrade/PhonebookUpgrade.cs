using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_phonebook_upgrade
{
    class PhonebookUpgrade
    {
        static void Main()
        {
            var phonebook = new SortedDictionary<string, string>();
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
                else if (command[0] == "ListAll")
                {
                    foreach (var contact in phonebook)
                    {
                        Console.WriteLine($"{contact.Key} -> {contact.Value}");
                    }
                }

                command = Console.ReadLine().Split(' ');
            }
        }
    }
}
/*

A Nakov +359888001122
A RoYaL(Ivan) 666
A Gero 5559393
A Simo 02/987665544
ListAll
END

*/
