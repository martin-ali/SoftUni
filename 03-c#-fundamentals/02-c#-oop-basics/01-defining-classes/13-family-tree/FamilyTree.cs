using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _13_family_tree
{
    class FamilyTree
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test2.txt"));
#endif

            var personToList = Console.ReadLine();

            var people = new List<Person>();
            var relations = new List<string>();

            var input = Console.ReadLine();
            while (input != "End")
            {
                var inputIsInformation = input.Contains('-') == false;
                if (inputIsInformation)
                {
                    var parameters = input.Split(' ');
                    var name = $"{parameters[0]} {parameters[1]}";
                    var birthDate = parameters[2];

                    people.Add(new Person(name, birthDate));
                }
                else
                {
                    relations.Add(input);
                }

                input = Console.ReadLine();
            }

            foreach (var relation in relations)
            {
                var data = relation.Split(" - ");
                var parentId = data[0];
                var childId = data[1];

                var parent = people.First(NameOrBirth(parentId, parentId));
                var child = people.First(NameOrBirth(childId, childId));

                parent.Children.Add(child);
                child.Parents.Add(parent);
            }

            var main = people.First(NameOrBirth(personToList, personToList));
            Console.WriteLine(main);

            Console.WriteLine("Parents:");
            foreach (var parent in main.Parents)
            {
                Console.WriteLine(parent);
            }

            Console.WriteLine("Children:");
            foreach (var child in main.Children)
            {
                Console.WriteLine(child);
            }
        }

        public static Func<Person, bool> NameOrBirth(string name, string birthDate)
        {
            return p => p.Name == name || p.BirthDate == birthDate;
        }
    }
}