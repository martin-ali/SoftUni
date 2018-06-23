using System;

namespace cups
{
    class Program
    {
        static void Main()
        {
            // int cupsTarget = 500;
            // int numberOfWorkers = 8;
            // int numberOfWorkdays = 20;

            int cupsTarget = int.Parse(Console.ReadLine());
            int numberOfWorkers = int.Parse(Console.ReadLine());
            int numberOfWorkdays = int.Parse(Console.ReadLine());

            decimal cupValue = 4.2m;
            decimal moneyTarget = cupsTarget * cupValue;
            int totalHoursWorked = numberOfWorkers * numberOfWorkdays * 8;
            int cupsMade = totalHoursWorked / 5;
            decimal moneyMade = cupsMade * cupValue;
            bool targetReached = moneyMade >= moneyTarget;

            if (targetReached)
            {
                Console.WriteLine($"{moneyMade - moneyTarget:0.00} extra money");
            }
            else
            {
                Console.WriteLine($"Losses: {moneyTarget - moneyMade:0.00}");
            }
        }
    }
}
