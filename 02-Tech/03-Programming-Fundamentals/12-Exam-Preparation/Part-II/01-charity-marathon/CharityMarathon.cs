using System;

namespace _01_charity_marathon
{
    class CharityMarathon
    {
        static void Main()
        {
            var marathonLengthInDays = int.Parse(Console.ReadLine());
            var runnerCount = int.Parse(Console.ReadLine());
            var lapsPerRunner = int.Parse(Console.ReadLine());
            var trackLengthInMeters = int.Parse(Console.ReadLine());
            var trackCapacity = int.Parse(Console.ReadLine());
            var moneyRaisedPerKm = decimal.Parse(Console.ReadLine());

            var runnerSlots = trackCapacity * marathonLengthInDays;
            var runnersThatRan = Math.Min(runnerSlots, runnerCount);
            var metersRan = (long)runnersThatRan * lapsPerRunner * trackLengthInMeters;
            var kilometersRan = metersRan / 1000;
            var moneyRaised = kilometersRan * moneyRaisedPerKm;

            Console.WriteLine($"Money raised: {moneyRaised:0.00}");
        }
    }
}
