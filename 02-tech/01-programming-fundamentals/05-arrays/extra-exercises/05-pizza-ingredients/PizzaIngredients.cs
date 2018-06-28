using System;
using System.Collections.Generic;

namespace _05_pizza_ingredients
{
    class PizzaIngredients
    {
        static void Main()
        {
            var possibleIngredients = Console.ReadLine().Split(' ');
            var ingredientLength = int.Parse(Console.ReadLine());

            var ingredients = new List<string>();
            for (int current = 0; current < possibleIngredients.Length && ingredients.Count < 10; current++)
            {
                var ingredient = possibleIngredients[current];
                if (ingredient.Length == ingredientLength)
                {
                    ingredients.Add(ingredient);
                    Console.WriteLine($"Adding {ingredient}.");
                }
            }

            Console.WriteLine($"Made pizza with total of {ingredients.Count} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ", ingredients)}.");
        }
    }
}
/*

cheese flour tomato bread olives salami pepperoni
6

cheese flour tomato bread olives salami pepperoni
9

 */
