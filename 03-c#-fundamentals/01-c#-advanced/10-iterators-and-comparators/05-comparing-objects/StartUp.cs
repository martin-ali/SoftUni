using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_comparing_objects
{
    class StartUp
    {
        static void Main()
        {
            var people = new List<Person>();

            var input = Console.ReadLine();
            while (input != "END")
            {
                var person = Person.Parse(input);

                people.Add(person);

                input = Console.ReadLine();
            }

            var indexToQuery = int.Parse(Console.ReadLine()) - 1;
            var personToQuery = people[indexToQuery];

            var equalPeople = people.Count(p => p.CompareTo(personToQuery) == 0);
            var notEqualPeople = people.Count(p => p.CompareTo(personToQuery) != 0);
            var totalPeople = people.Count;

            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {notEqualPeople} {totalPeople}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
