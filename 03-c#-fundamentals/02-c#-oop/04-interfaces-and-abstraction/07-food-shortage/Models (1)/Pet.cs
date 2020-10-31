namespace _07_food_shortage.Models
{
    using System;
    using _07_food_shortage.Interfaces;

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