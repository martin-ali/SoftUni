using System;

namespace Repository
{
    public class Person
    {
        public Person(string name, int age, DateTime birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthDate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public DateTime Birthdate { get; private set; }
    }
}