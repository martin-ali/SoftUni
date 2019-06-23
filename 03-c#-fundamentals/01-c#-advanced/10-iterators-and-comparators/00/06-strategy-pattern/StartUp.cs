using System;
using System.Collections.Generic;

namespace _06_strategy_pattern
{
    class StartUp
    {
        static void Main()
        {
            var peopleSortedByName = new SortedSet<Person>(new PersonByNameComparer());
            var peopleSortedByAge = new SortedSet<Person>(new PersonByAgeComparer());

            var peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                var person = Person.Parse(Console.ReadLine());

                peopleSortedByName.Add(person);
                peopleSortedByAge.Add(person);
            }

            foreach (var person in peopleSortedByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in peopleSortedByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
