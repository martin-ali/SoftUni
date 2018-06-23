using System;
using System.Linq;

namespace _06_heists
{
    class Heists
    {
        static void Main()
        {
            var pricing = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var prices = (jewels: pricing[0], gold: pricing[1]);

            var moneyLost = 0L;
            var moneyGained = 0L;
            var act = Console.ReadLine();
            while (act != "Jail Time")
            {
                var heist = act.Split(' ');
                var loot = heist[0];
                var expenses = int.Parse(heist[1]);

                moneyGained += loot.Count(item => item.Equals('%')) * prices.jewels;
                moneyGained += loot.Count(item => item.Equals('$')) * prices.gold;
                moneyLost += expenses;

                act = Console.ReadLine();
            }

            if (moneyGained >= moneyLost)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {moneyGained - moneyLost}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {moneyLost - moneyGained}.");
            }
        }
    }
}
/*

10 20
ASDA% 50
DaS@!%$$ 10
$$ 10
Jail Time

2000 10000
ASDAs 500000
%ASD$ 1000000
$S$&amp;*_ASD 1000
AF#^&amp;*LP 20000
$ 100000000
Jail Time

 */
