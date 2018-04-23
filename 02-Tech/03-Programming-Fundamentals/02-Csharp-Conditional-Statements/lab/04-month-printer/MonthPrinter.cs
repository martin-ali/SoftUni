using System;

namespace _04_month_printer
{
    class MonthPrinter
    {
        static void Main()
        {
            var months = new string[]
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December",
            };

            int number = int.Parse(Console.ReadLine());
            if (1 <= number && number <= 12)
            {
                Console.WriteLine(months[number - 1]);
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
