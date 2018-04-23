using System;

namespace Time_Plus_15_Minutes
{
    class Program
    {
        static void Main()
        {
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());

            var minutesExtended = minutes + 15;
            if (minutesExtended >= 60)
            {
                hours += 1;
                minutesExtended -= 60;
            }

            if (hours >= 24)
            {
                hours -= 24;
            }

            Console.WriteLine($"{hours}:{minutesExtended:00}");
        }
    }
}
