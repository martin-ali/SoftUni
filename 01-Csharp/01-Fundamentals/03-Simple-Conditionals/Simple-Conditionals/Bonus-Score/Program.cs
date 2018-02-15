using System;

namespace Bonus_Score
{
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            double points = 0;
            double bonusPoints = 0;

            if (number <= 100)
            {
                points += 5d;
            }
            else if (number > 100 && number <= 1000)
            {
                points += number / 5d;
            }
            else if (number > 1000)
            {
                points += number / 10d;
            }

            if (number % 2d == 0)
            {
                bonusPoints++;
            }

            if (number % 10d == 5)
            {
                bonusPoints += 2d;
            }

            Console.WriteLine(points+bonusPoints);
            Console.WriteLine(number+points+bonusPoints);
        }
    }
}
