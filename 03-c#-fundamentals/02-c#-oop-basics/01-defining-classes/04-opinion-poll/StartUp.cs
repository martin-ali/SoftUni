using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var family = new Family();
            var personCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < personCount; i++)
            {
                var data = Console.ReadLine().Split();
                var name = data[0];
                var age = int.Parse(data[1]);

                family.AddMember(new Person(name, age));
            }

            var peopleOver30 = family.GetPeopleWhere(p => p.Age > 30).OrderBy(p => p.Name);
            foreach (var person in peopleOver30)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}