using System;

namespace _01_rage_expenses
{
    class RageExpenses
    {
        static void Main()
        {
            var lostGames = int.Parse(Console.ReadLine());
            var headsetPrice = decimal.Parse(Console.ReadLine());
            var mousePrice = decimal.Parse(Console.ReadLine());
            var keyboardPrice = decimal.Parse(Console.ReadLine());
            var displayPrice = decimal.Parse(Console.ReadLine());

            var headsetsTrashed = lostGames / 2;
            var miceTrashed = lostGames / 3;
            var keyboardsTrashed = lostGames / 6; // When Both headset and mouse get trashed
            var displaysTrashed = lostGames / 12; // On every second trashing of the keyboard

            var totalDamage = (headsetsTrashed * headsetPrice)
                            + (miceTrashed * mousePrice)
                            + (keyboardsTrashed * keyboardPrice)
                            + (displaysTrashed * displayPrice);

            Console.WriteLine($"Rage expenses: {totalDamage:0.00} lv.");
        }
    }
}

/*

7
2
3
4
5

23
12.50
21.50
40
200

 */
