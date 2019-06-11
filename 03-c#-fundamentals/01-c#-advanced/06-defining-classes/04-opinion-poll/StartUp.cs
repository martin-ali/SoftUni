using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main()
        {
            var people = new List<Person>();
            var peopleCount = int.Parse(Console.ReadLine());
            for (int current = 0; current < peopleCount; current++)
            {
                var parameters = Console.ReadLine().Split();
                var name = parameters[0];
                var age = int.Parse(parameters[1]);

                people.Add(new Person(name, age));
            }

            var peopleOver30Sorted = people
                                        .Where(p => p.Age > 30)
                                        .OrderBy(p => p.Name);

            foreach (var person in peopleOver30Sorted)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
