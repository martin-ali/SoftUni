using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_upgraded_matcher
{
    class UpgradedMatcher
    {
        static void Main()
        {
            // String would work just as well for all three arrays
            var productNames = Console.ReadLine().Split(' ');
            var quantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            // Fill dictionary with products
            var products = new Dictionary<string, (string name, long quantity, decimal price)>();
            for (int current = 0; current < prices.Length; current++)
            {
                var quantity = quantities.Length > current ? quantities[current] : 0;
                var product = (productNames[current], quantity, prices[current]);
                products[productNames[current]] = product;
            }

            var command = Console.ReadLine();
            while (command != "done")
            {
                var args = command.Split(' ');
                var name = args[0];
                var order = long.Parse(args[1]);

                var product = products[name];
                if (product.quantity >= order)
                {
                    var price = order * product.price;
                    Console.WriteLine($"{product.name} x {order} costs {price:0.00}");
                    product.quantity -= order;

                    // Something went wrong here. Need to improve design
                    products[name] = product;
                }
                else
                {
                    Console.WriteLine($"We do not have enough {product.name}");
                }

                command = Console.ReadLine();
            }
        }
    }
}
/*

Bread Juice Fruits Lemons Beer
10 50 20 30
2.34 1.23 3.42 1.50 3.00
Bread 10
Juice 5
Beer 20
done

Tomatoes Onions Lemons
10000 2000
5.40 3.20 2.20
Tomatoes 5000
Tomatoes 5000
Tomatoes 1
done

 */
