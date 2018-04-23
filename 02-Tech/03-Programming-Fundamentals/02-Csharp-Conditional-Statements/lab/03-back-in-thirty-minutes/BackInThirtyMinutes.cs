using System;

namespace _03_back_in_30_minutes
{
    class BackInThirtyMinutes
    {
        // Alternative: turn everything to minutes first
        static void Main()
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine()) + 30;

            if (minutes > 59)
            {
                hours++;
                minutes -= 60;
            }

            if (hours > 23)
            {
                hours -= 24;
            }

            Console.WriteLine($"{hours}:{minutes:00}");
        }
    }
}
