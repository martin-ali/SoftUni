using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04_supermarket_database
{
    class SupermarketDatabase
    {
        static void Main()
        {

            #if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
            #endif

            var pricesAndQuantitiesByProduct = new Dictionary<string, (decimal price, int quantity)>();

            var input = Console.ReadLine().Split(' ');
            while (input[0] != "stocked")
            {
                var name = input[0];
                var price = decimal.Parse(input[1]);
                var quantity = int.Parse(input[2]);

                var product = (price: price, quantity: quantity);

                if (pricesAndQuantitiesByProduct.ContainsKey(name))
                {
                    product.quantity += pricesAndQuantitiesByProduct[name].quantity;
                }

                pricesAndQuantitiesByProduct[name] = product;

                input = Console.ReadLine().Split(' ');
            }

            foreach (var product in pricesAndQuantitiesByProduct)
            {
                Console.WriteLine($"{product.Key}: ${product.Value.price:F2} * {product.Value.quantity} = ${product.Value.price * product.Value.quantity:F2}");
            }

            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Grand Total: ${pricesAndQuantitiesByProduct.Select(pr => pr.Value.price * pr.Value.quantity).Sum():F2}");
        }
    }
}
