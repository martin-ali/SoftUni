using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _08_match_dates
{
    class Program
    {
        static void Main()
        {
            var dates = Console.ReadLine();

            var pattern = @"\b(?<day>[0-9]{2})(\.|-|\/)(?<month>[A-Z][a-z]{2})\1(?<year>[0-9]{4})\b";
            var matchedDates = Regex.Matches(dates, pattern);

            foreach (Match date in matchedDates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
// 13/Jul/1928, 10-Nov-1934, , 01/Jan-1951,f 25.Dec.1937 23/09/1973, 1/Feb/2016