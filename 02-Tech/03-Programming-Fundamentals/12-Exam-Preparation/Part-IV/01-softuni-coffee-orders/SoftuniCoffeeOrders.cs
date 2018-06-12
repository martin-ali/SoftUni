using System;
using System.Globalization;

namespace _01_softuni_coffee_orders
{
    class SoftuniCoffeeOrders
    {
        static void Main()
        {
            var orderCount = int.Parse(Console.ReadLine());
            var total = 0M;

            for (int i = 0; i < orderCount; i++)
            {
                var price = decimal.Parse(Console.ReadLine());
                var date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                var capsuleCount = long.Parse(Console.ReadLine());

                int dayCount = DateTime.DaysInMonth(date.Year, date.Month);
                var orderPrice = dayCount * capsuleCount * price;
                Console.WriteLine($"The price for the coffee is: ${orderPrice:0.00}");

                total += orderPrice;
            }

            Console.WriteLine($"Total: ${total:0.00}");
        }
    }
}
