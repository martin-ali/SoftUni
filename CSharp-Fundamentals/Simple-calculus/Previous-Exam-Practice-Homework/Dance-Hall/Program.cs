using System;

namespace Dance_Hall
{
    class Program
    {
        static void Main()
        {
            //var hallLengthInMeters = 50;
            //var hallWidthInMeters = 25;
            //var wardrobeSideInCeintimeterSquared = (2 * 2) * 10000;

            var hallLengthInMeters = double.Parse(Console.ReadLine());
            var hallWidthInMeters = double.Parse(Console.ReadLine());
            var wardrobeSideInMeters = double.Parse(Console.ReadLine());
            var wardrobeSideInCeintimetersSquared = (wardrobeSideInMeters * wardrobeSideInMeters) * 10000;

            double spaceTakenByEachDancerInSquareMeters = 7000 + 40;
            double hallArea = hallLengthInMeters * hallWidthInMeters * 10000;
            double spaceTakenByBench = hallArea / 10;

            double totalFreeArea =
                (hallArea - spaceTakenByBench - wardrobeSideInCeintimetersSquared)
                / spaceTakenByEachDancerInSquareMeters;

            Console.WriteLine($"{Math.Floor(totalFreeArea):0}");
        }
    }
}
