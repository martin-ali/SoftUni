using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _01_count_working_days
{
    class CountWorkingDays
    {
        static void Main()
        {
            #if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
            #endif

            var start = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var end = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var workdayCount = 0;
            const int RandomYear = 1985;
            var holidays = new int[]
            {
                new DateTime(RandomYear, 1, 1).DayOfYear,
                new DateTime(RandomYear, 3, 3).DayOfYear,
                new DateTime(RandomYear, 5, 1).DayOfYear,
                new DateTime(RandomYear, 5, 6).DayOfYear,
                new DateTime(RandomYear, 5, 24).DayOfYear,
                new DateTime(RandomYear, 9, 6).DayOfYear,
                new DateTime(RandomYear, 9, 22).DayOfYear,
                new DateTime(RandomYear, 9, 22).DayOfYear,
                new DateTime(RandomYear, 11, 1).DayOfYear,
                new DateTime(RandomYear, 12, 24).DayOfYear,
                new DateTime(RandomYear, 12, 25).DayOfYear,
                new DateTime(RandomYear, 12, 26).DayOfYear,
            };

            for (DateTime day = start; day <= end; day = day.AddDays(1))
            {
                bool dayIsHoliday = day.DayOfWeek == DayOfWeek.Saturday
                                    || day.DayOfWeek == DayOfWeek.Sunday
                                    || holidays.Contains(day.DayOfYear);
                if (dayIsHoliday == false)
                {
                    workdayCount++;
                }
            }

            Console.WriteLine(workdayCount);
        }
    }
}
