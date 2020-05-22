namespace _04_pizza_calories
{
    using System;
    using System.Collections.Generic;

    public class Topping : Ingredient
    {
        private const int MIN_WEIGHT = 1;

        private const int MAX_WEIGHT = 50;

        private readonly Dictionary<string, double> caloriesPerGramByType = new Dictionary<string, double>()
        {
            ["meat"] = 1.2,
            ["veggies"] = 0.8,
            ["cheese"] = 1.1,
            ["sauce"] = 0.9
        };

        private readonly string type;

        public Topping(string type, int weightGrams)
            : base(weightGrams)
        {
            var weightIsValid = MIN_WEIGHT <= weightGrams && weightGrams <= MAX_WEIGHT;
            if (weightIsValid == false)
            {
                throw new ArgumentException($"{type} weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }
            else if (this.caloriesPerGramByType.ContainsKey(type.ToLower()) == false)
            {
                throw new ArgumentException($"Cannot place {type} on top of your pizza.");
            }

            this.type = type.ToLower();
        }

        public override double Calories
        {
            get
            {
                return 2
                    * this.WeightGrams
                    * this.caloriesPerGramByType[this.type];
            }
        }
    }
}