namespace _05_greedy_times
{

    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            var capacity = long.Parse(Console.ReadLine());
            var bag = new Bag(capacity);
            var safe = new Safe(Console.ReadLine());

            foreach (var item in safe.Items)
            {
                if (bag.IsFull) break;

                bag.AddItem(item);
            }

            Console.WriteLine(bag);
        }
    }
}
/*

150
Gold 28 Rubygem 16 USD 9 GBP 8

24000010
USD 1030 Gold 300000 EmeraldGem 900000 Topazgem 290000 CHF 280000 Gold 10000000 JPN 10000 Rubygem 10000000 KLM 3120010

80345
RubyGem 70000 JAV 10960 Bau 60000 Gold 80000

*/
