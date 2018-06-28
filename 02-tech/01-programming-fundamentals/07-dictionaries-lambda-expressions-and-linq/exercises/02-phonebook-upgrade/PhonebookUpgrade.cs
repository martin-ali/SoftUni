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
            var parameters = Console.ReadLine().Split(' ');
            while (parameters[0] != ("END"))
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
                else if (parameters[0] == "ListAll")
                {
                    foreach (var contact in phonebook)
                    {
                        Console.WriteLine($"{contact.Key} -> {contact.Value}");
                    }
                }

                parameters = Console.ReadLine().Split(' ');
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
