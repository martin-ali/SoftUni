using System;
using System.Collections.Generic;
using System.Globalization;

namespace _12_google
{
    class Google
    {
        static void Main()
        {
            var people = new Dictionary<string, Person>();
            var input = Console.ReadLine();
            while (input != "End")
            {
                var data = input.Split();
                var name = data[0];
                var informationType = data[1];

                if (people.ContainsKey(name) == false)
                {
                    people[name] = new Person(name);
                }

                var person = people[name];
                if (informationType == "company")
                {
                    person.Company = new Workplace(data[2], data[3], decimal.Parse(data[4]));
                }
                else if (informationType == "pokemon")
                {
                    person.Pokemon.Add(new Pokemon(data[2], data[3]));
                }
                else if (informationType == "parents")
                {
                    person.Parents.Add(new Relative(data[2], data[3]));
                }
                else if (informationType == "children")
                {
                    person.Children.Add(new Relative(data[2], data[3]));
                }
                else if (informationType == "car")
                {
                    person.Car = new Car(data[2], int.Parse(data[3]));
                }

                input = Console.ReadLine();
            }

            var personToList = Console.ReadLine();
            var listedPerson = people[personToList];

            Console.WriteLine(listedPerson);
        }
    }
}
