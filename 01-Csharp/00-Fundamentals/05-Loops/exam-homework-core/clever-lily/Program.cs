using System;

namespace clever_lily
{
    class Program
    {
        static void Main()
        {
            int ageOfLily = int.Parse(Console.ReadLine());
            decimal washingMachinePrice = decimal.Parse(Console.ReadLine());
            int pricePerToy = int.Parse(Console.ReadLine());
            
            int numberOfToysOwned = 0;
            decimal sumOfMoneyOwned = 0;
            for (int birthday = 1, giftMoney = 10; birthday <= ageOfLily; birthday++)
            {
                if (birthday % 2 == 0)
                {
                    sumOfMoneyOwned -= 1;
                    sumOfMoneyOwned += giftMoney;
                    giftMoney += 10;
                }
                else
                {
                    numberOfToysOwned++;
                }
            }

            var totalSumGathered = sumOfMoneyOwned + (numberOfToysOwned * pricePerToy);
            
            if (totalSumGathered >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {totalSumGathered - washingMachinePrice:0.00}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice - totalSumGathered:0.00}");                
            }
        }
    }
}
