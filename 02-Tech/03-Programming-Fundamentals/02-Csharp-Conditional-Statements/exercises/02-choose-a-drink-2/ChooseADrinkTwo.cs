using System;

namespace _02_choose_a_drink_2
{
    class ChooseADrinkTwo
    {
        static void Main()
        {
            var prices = (water: 0.7m, coffee: 1m, beer: 1.7m, tea: 1.2m);
            var profession = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            var totalPrice = quantity * prices.tea;

            switch (profession)
            {
                case "Athlete":
                    totalPrice = quantity * prices.water; break;
                case "Businessman":
                case "Businesswoman":
                    totalPrice = quantity * prices.coffee; break;
                case "SoftUni Student":
                    totalPrice = quantity * prices.beer; break;
            }

            Console.WriteLine($"The {profession} has to pay {totalPrice:0.00}.");
        }
    }
}
