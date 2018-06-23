using System;

namespace _04_beverage_labels
{
    class BeverageLabels
    {
        static void Main()
        {
            var name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            double sugar = double.Parse(Console.ReadLine());
            double portion = volume / 100d;

            Console.WriteLine($"{volume}ml {name}:");
            Console.WriteLine($"{energy * portion}kcal, {sugar * portion}g sugars");
        }
    }
}
