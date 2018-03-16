using System;
using System.Numerics;

namespace anonymous_downsite
{
    class Program
    {
        static void Main()
        {
            byte numberOfDownedWebsites = byte.Parse(Console.ReadLine());
            byte securityKey = byte.Parse(Console.ReadLine());
            decimal totalLosses = 0;

            for (long current = 0; current < numberOfDownedWebsites; current++)
            {
                var rawInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var site = (name: rawInfo[0], visits: long.Parse(rawInfo[1]), pricePerVisit: decimal.Parse(rawInfo[2]));

                totalLosses += site.visits * site.pricePerVisit;
                Console.WriteLine(site.name);
            }

            Console.WriteLine($"Total Loss: {totalLosses:f20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(securityKey, numberOfDownedWebsites)}");
        }
    }
}
