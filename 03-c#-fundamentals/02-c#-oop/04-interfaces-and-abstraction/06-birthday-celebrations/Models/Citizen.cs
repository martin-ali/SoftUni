namespace _06_birthday_celebrations.Models
{
    using System;
    using _06_birthday_celebrations.Interfaces;

    public class Citizen : IIdentifiable, INamed, IHasBirthdate
    {
        public Citizen(string name, int age, string id, DateTime birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }

        public string Name { get; }

        public int Age { get; }

        public string Id { get; }

        public DateTime BirthDate { get; }
    }
}