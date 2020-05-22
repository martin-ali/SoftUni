namespace _04_pizza_calories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza : IHasCalories
    {
        private const int MAX_TOPPINGS_COUNT = 10;

        private const int MIN_NAME_LENGTH = 1;

        private const int MAX_NAME_LENGTH = 15;

        public Pizza(string name, Dough dough, params Topping[] toppings)
        {
            var pizzaNameIsValid = MIN_NAME_LENGTH <= name.Length && name.Length <= MAX_NAME_LENGTH;
            if (pizzaNameIsValid == false)
            {
                throw new ArgumentException($"Pizza name should be between {MIN_NAME_LENGTH} and {MAX_NAME_LENGTH} symbols.");
            }

            this.Name = name;
            this.Dough = dough;

            foreach (var topping in toppings)
            {
                this.AddTopping(topping);
            }
        }

        public Dough Dough { get; set; }

        private List<Topping> Toppings { get; } = new List<Topping>();

        public string Name { get; }

        public int ToppingsCount => this.Toppings.Count;

        public double Calories
        {
            get
            {
                double doughCalories = this.Dough.Calories;
                double toppingsCalories = this.Toppings.Sum(t => t.Calories);
                return doughCalories + toppingsCalories;
            }
        }

        public void AddTopping(Topping topping)
        {
            this.Toppings.Add(topping);
        }

        public void AddTopping(string type, int weightGrams)
        {
            this.Toppings.Add(new Topping(type, weightGrams));

            if (this.ToppingsCount > MAX_TOPPINGS_COUNT)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MAX_TOPPINGS_COUNT}].");
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:0.00} Calories.";
        }
    }
}