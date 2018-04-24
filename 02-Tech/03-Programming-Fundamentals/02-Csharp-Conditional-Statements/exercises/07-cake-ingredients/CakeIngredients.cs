using System;

namespace _07_cake_ingredients
{
    class CakeIngredients
    {
        static void Main()
        {
            int numberOfIngredients = 0;
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "Bake!")
                {
                    Console.WriteLine($"Preparing cake with {numberOfIngredients} ingredients.");
                    break;
                }
                else
                {
                    Console.WriteLine($"Adding ingredient {command}.");
                    numberOfIngredients++;
                }
            }
        }
    }
}
