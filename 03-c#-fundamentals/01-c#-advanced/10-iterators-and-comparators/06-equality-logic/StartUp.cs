using System;
using System.Collections.Generic;

namespace _06_equality_logic
{
    class StartUp
    {
        static void Main()
        {
            var peopleSortedSet = new SortedSet<Person>();
            var peopleHashSet = new HashSet<Person>();

            var peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                var person = Person.Parse(Console.ReadLine());

                peopleSortedSet.Add(person);
                peopleHashSet.Add(person);
            }

            Console.WriteLine(peopleSortedSet.Count);
            Console.WriteLine(peopleHashSet.Count);
        }
    }
}
