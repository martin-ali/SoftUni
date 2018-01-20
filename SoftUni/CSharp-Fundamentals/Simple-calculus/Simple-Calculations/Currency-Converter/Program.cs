using System;
using System.Collections.Generic;

namespace Currency_Converter
{
    class Program
    {
        const decimal BGN_TO_USD_COURSE = 1.79549m;

        const decimal BGN_TO_EUR_COURSE = 1.95583m;

        const decimal BGN_TO_GBP_COURSE = 2.53405m;

        private static Dictionary<string, decimal> bgnToOtherCourses = new Dictionary<string, decimal>
        {
            ["USD"] = BGN_TO_USD_COURSE,
            ["EUR"] = BGN_TO_EUR_COURSE,
            ["GBP"] = BGN_TO_GBP_COURSE,
            ["BGN"] = 1
        };

        static void Main()
        {
            var initialValue = decimal.Parse(Console.ReadLine());
            var currencyToConvertFrom = Console.ReadLine();
            var currencyToConvertTo = Console.ReadLine();

            var valueInBgn = ConvertAnyCurrencyToBgn(initialValue, currencyToConvertFrom);
            var valueConvertedToNewCurrency = ConvertBgnToAnyCurrency(valueInBgn, currencyToConvertTo);

            var resultRounded = Math.Round(valueConvertedToNewCurrency, 2);
            Console.WriteLine($"{resultRounded} {currencyToConvertTo}");
        }

        private static decimal ConvertBgnToAnyCurrency(decimal bgnToConvert, string currencyToConvertTo)
        {
            return bgnToConvert / bgnToOtherCourses[currencyToConvertTo];
        }

        private static decimal ConvertAnyCurrencyToBgn(decimal valueToConvert, string currencyToConvertFrom)
        {
            return valueToConvert * bgnToOtherCourses[currencyToConvertFrom];
        }
    }
}
