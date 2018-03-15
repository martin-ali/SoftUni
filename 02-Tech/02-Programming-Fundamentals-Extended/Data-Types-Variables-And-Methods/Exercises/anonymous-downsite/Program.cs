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
                var site = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                totalLosses += long.Parse(site[1]) * decimal.Parse(site[2]);
                Console.WriteLine(site[0]);
            }

            Console.WriteLine($"Total Loss: {totalLosses:f20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(securityKey, numberOfDownedWebsites)}");
        }
    }
}
