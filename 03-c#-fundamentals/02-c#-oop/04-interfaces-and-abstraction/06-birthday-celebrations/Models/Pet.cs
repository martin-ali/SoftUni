namespace _06_birthday_celebrations.Models
{
    using System;
    using _06_birthday_celebrations.Interfaces;

    public class Pet : INamed, IHasBirthdate
    {
        public Pet(string name, DateTime birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public string Name { get; }

        public DateTime BirthDate { get; }
    }
}