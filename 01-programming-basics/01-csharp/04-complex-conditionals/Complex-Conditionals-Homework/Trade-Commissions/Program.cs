using System;

namespace Trade_Commissions
{
    class Program
    {
        static void Main()
        {
            var city = Console.ReadLine().ToLower();
            var sales = double.Parse(Console.ReadLine());
            var rate = -1d;

            if (sales > 10000)
            {
                if (city == "sofia")
                {
                    rate = 0.12;
                }
                else if (city == "varna")
                {
                    rate = 0.13;
                }
                else if (city == "plovdiv")
                {
                    rate = 0.145;
                }
            }
            else if (1000 < sales && sales <= 10000)
            {
                if (city == "sofia")
                {
                    rate = 0.08;
                }
                else if (city == "varna")
                {
                    rate = 0.10;
                }
                else if (city == "plovdiv")
                {
                    rate = 0.12;
                }
            }
            else if (500 < sales && sales <= 1000)
            {
                if (city == "sofia")
                {
                    rate = 0.07;
                }
                else if (city == "varna")
                {
                    rate = 0.075;
                }
                else if (city == "plovdiv")
                {
                    rate = 0.08;
                }
            }
            else if (0 <= sales && sales <= 500)
            {
                if (city == "sofia")
                {
                    rate = 0.05;
                }
                else if (city == "varna")
                {
                    rate = 0.045;
                }
                else if (city == "plovdiv")
                {
                    rate = 0.055;
                }
            }

            if (rate > -1)
            {
                var commission = rate * sales;
                Console.WriteLine($"{commission:0.00}");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
