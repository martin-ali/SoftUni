using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_inventory_matcher
{
    class InventoryMatcher
    {
        static void Main()
        {
            // String would work just as well for all three arrays
            var productNames = Console.ReadLine().Split(' ');
            var quantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            // Fill dictionary with products
            var products = new Dictionary<string, (string name, long quantity, decimal price)>();
            for (int current = 0; current < quantities.Length; current++)
            {
                var product = (productNames[current], quantities[current], prices[current]);
                products[productNames[current]] = product;
            }

            var name = Console.ReadLine();
            while (name != "done")
            {
                var product = products[name];
                Console.WriteLine($"{product.name} costs: {product.price}; Available quantity: {product.quantity}");

                name = Console.ReadLine();
            }
        }
    }
}
/*

Bread Juice Fruits Lemons
10 50 20 30
2.34 1.23 3.42 1.50
Bread
Juice
done

Oranges Apples Nuts
1500 5000000 2000000000
2.3412 1.23 3.4250
Nuts
done

 */
