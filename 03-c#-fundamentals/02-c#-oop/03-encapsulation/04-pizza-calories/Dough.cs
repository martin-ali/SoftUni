namespace _04_pizza_calories
{
    using System;
    using System.Collections.Generic;

    public class Dough : Ingredient, IHasCalories
    {
        private const int MIN_WEIGHT = 1;

        private const int MAX_WEIGHT = 200;

        private readonly string flour;

        private readonly string bakingTechnique;

        private readonly Dictionary<string, double> caloriesPerGramByFlour = new Dictionary<string, double>()
        {
            ["white"] = 1.5,
            ["wholegrain"] = 1
        };

        private readonly Dictionary<string, double> caloriesPerGramByBakingTechnique = new Dictionary<string, double>()
        {
            ["crispy"] = 0.9,
            ["chewy"] = 1.1,
            ["homemade"] = 1
        };

        public Dough(string flour, string bakingTechnique, int weightGrams)
            : base(weightGrams)
        {
            var weightIsValid = MIN_WEIGHT <= weightGrams && weightGrams <= MAX_WEIGHT;
            if (weightIsValid == false)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }
            else if (this.caloriesPerGramByBakingTechnique.ContainsKey(bakingTechnique.ToLower()) == false
               || this.caloriesPerGramByFlour.ContainsKey(flour.ToLower()) == false)
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flour = flour.ToLower();
            this.bakingTechnique = bakingTechnique.ToLower();
        }

        public override double Calories
        {
            get
            {
                return 2
                    * this.WeightGrams
                    * this.caloriesPerGramByFlour[this.flour]
                    * this.caloriesPerGramByBakingTechnique[this.bakingTechnique];
            }
        }
    }
}