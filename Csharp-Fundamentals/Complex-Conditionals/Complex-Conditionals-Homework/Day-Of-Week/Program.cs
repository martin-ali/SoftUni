using System;

namespace Day_Of_Week
{
    class Program
    {
        static void Main()
        {
            var day = int.Parse(Console.ReadLine());
            var daysToNumbers = new string[]
            {
                "monday",
                "tuesday",
                "wednesday",
                "thursday",
                "friday",
                "saturday",
                "sunday",
            };

            var dayOfWeek = (day >= 1 && day <= 7) ? daysToNumbers[day - 1] : "Error";
            Console.WriteLine(dayOfWeek);
        }
    }
}
