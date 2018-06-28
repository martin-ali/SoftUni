using System;
using System.Numerics;

namespace _01_anonymous_downsite
{
    class AnonymousDownsite
    {
        static void Main()
        {
            var downedSiteCount = int.Parse(Console.ReadLine());
            var securityKey = int.Parse(Console.ReadLine());
            var totalLosses = 0m;

            for (int i = 0; i < downedSiteCount; i++)
            {
                var siteData = Console.ReadLine().Split();

                var name = siteData[0];
                var visits = long.Parse(siteData[1]);
                var pricePerVisit = decimal.Parse(siteData[2]);
                var loss = visits * pricePerVisit;

                totalLosses += loss;

                Console.WriteLine(name);
            }

            Console.WriteLine($"Total Loss: {totalLosses:f20}");

            var securityToken = BigInteger.Pow(securityKey, downedSiteCount);
            Console.WriteLine($"Security Token: {securityToken}");
        }
    }
}
