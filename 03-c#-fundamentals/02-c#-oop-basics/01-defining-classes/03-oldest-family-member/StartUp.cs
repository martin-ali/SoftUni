using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var people = new Family();
            var personCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < personCount; i++)
            {
                var data = Console.ReadLine().Split();
                var name = data[0];
                var age = int.Parse(data[1]);

                people.AddMember(new Person(name, age));
            }

            var oldestPerson = people.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}