namespace SandwichMaker.Models
{
    using System;

    public class Sandwich : SandwichPrototype
    {
        private string veggies;
        private string bread;
        private string cheese;
        private string meat;

        public Sandwich(string meat, string cheese, string bread, string veggies)
        {
            this.meat = meat;
            this.cheese = cheese;
            this.bread = bread;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            var ingredients = this.GetIngredients();
            Console.WriteLine($"Cloning sandwich with ingredients: {ingredients}");

            return (SandwichPrototype)this.MemberwiseClone();
        }

        private string GetIngredients()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}
