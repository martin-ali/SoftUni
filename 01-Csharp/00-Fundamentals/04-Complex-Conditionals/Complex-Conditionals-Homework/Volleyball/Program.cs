using System;

namespace Volleyball
{
    class Program
    {
        static void Main()
        {
            // Forced myself to finish this afterall
            var yearType = Console.ReadLine().ToLower();
            var numberOfHolidaysInYear = int.Parse(Console.ReadLine());
            var numberOfWeekends = int.Parse(Console.ReadLine());

            double WeekendsInSofia = (48 - numberOfWeekends) * (3d / 4d);
            var gamesInSofiaOnHoliday = numberOfHolidaysInYear * (2d / 3d);
            double numberOfGamesDuringYear = WeekendsInSofia + numberOfWeekends + gamesInSofiaOnHoliday;

            if (yearType == "leap")
            {
                numberOfGamesDuringYear *= 1.15;
            }

            var result = Math.Floor(numberOfGamesDuringYear);
            Console.WriteLine(result);
        }
    }
}
