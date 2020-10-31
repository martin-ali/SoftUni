namespace _07_food_shortage.Models
{
    using System;
    using _07_food_shortage.Interfaces;

    public class Citizen : IIdentifiable, INamed, IHasAge, IHasBirthdate, IBuyer
    {
        private const int CITIZEN_FOOD_RATION = 10;

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

        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            this.Food += CITIZEN_FOOD_RATION;
        }
    }
}