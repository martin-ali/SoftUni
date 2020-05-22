namespace _04_pizza_calories
{
    using System;

    public abstract class Ingredient : IHasCalories
    {
        protected Ingredient(int weightGrams)
        {
            this.WeightGrams = weightGrams;
        }

        protected int WeightGrams { get; }

        public abstract double Calories { get; }
    }
}