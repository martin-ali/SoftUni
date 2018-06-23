using System;

namespace _01_choose_a_drink
{
    class ChooseADrink
    {
        static void Main()
        {
            var profession = Console.ReadLine();
            var drink = "Tea";

            switch (profession)
            {
                case "Athlete":
                    drink = "Water"; break;
                case "Businessman":
                case "Businesswoman":
                    drink = "Coffee"; break;
                case "SoftUni Student":
                    drink = "Beer"; break;
            }

            Console.WriteLine(drink);
        }
    }
}
