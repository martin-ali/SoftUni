using System;

namespace Usd_to_Bgn
{
    class Program
    {
        const decimal BGN_TO_USD_COURSE = 1.79549m;

        static void Main()
        {
            var valueInBgn = decimal.Parse(Console.ReadLine());

            var valueConvertedToUsd = valueInBgn * BGN_TO_USD_COURSE;
            var valueInUsdRounded = Math.Round(valueConvertedToUsd, 2);

            Console.WriteLine(valueInUsdRounded);
        }
    }
}
