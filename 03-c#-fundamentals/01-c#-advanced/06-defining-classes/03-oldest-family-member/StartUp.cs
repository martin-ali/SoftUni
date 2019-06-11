using System;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main()
        {
            var Family = new Family();
            var peopleCount = int.Parse(Console.ReadLine());
            for (int current = 0; current < peopleCount; current++)
            {
                var parameters = Console.ReadLine().Split();
                var name = parameters[0];
                var age = int.Parse(parameters[1]);

                var person = new Person(name, age);
                Family.AddMember(person);
            }

            var oldestPerson = Family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
