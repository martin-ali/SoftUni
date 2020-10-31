namespace _03_wild_farm.Models.Animals
{
    using System;
    using System.Linq;
    using _03_wild_farm.Models.Foods;

    public abstract class Animal
    {
        protected abstract string[] itemsToPrint { get; }

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public int FoodEaten { get; private set; } = 0;

        public double Weight { get; private set; }

        protected abstract Type[] allowedFoods { get; }

        protected abstract double WeightGainPerKgFood { get; }

        public string Name { get; }

        public abstract string MakeSound();

        public void Eat(Food food)
        {
            var foodIsAllowed = this.allowedFoods.Any(t => t.IsAssignableFrom(food.GetType()));
            if (foodIsAllowed == false)
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            var weightGained = this.WeightGainPerKgFood * food.Quantity;
            this.Weight += weightGained;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{string.Join(", ", this.itemsToPrint)}]";
        }
    }
}