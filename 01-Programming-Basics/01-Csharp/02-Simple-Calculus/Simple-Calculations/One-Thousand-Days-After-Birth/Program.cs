using System;
using System.Globalization;

namespace One_Thousand_Days_After_Birth
{
    class Program
    {
        static void Main()
        {
            var startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var endDate = startDate
                            .AddDays(999) // Why 999?
                            .ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(endDate);
        }
    }
}
