using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07_andrey_and_billiard
{
    class AndreyAndBilliard
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("test.txt"));
            #endif

            var numberOfProducts = int.Parse(Console.ReadLine());
            var pricesByProduct = new Dictionary<string, decimal>();
            for (int i = 0; i < numberOfProducts; i++)
            {
                var parameters = Console.ReadLine().Split('-');
                var product = parameters[0];
                var price = decimal.Parse(parameters[1]);

                pricesByProduct[product] = price;
            }

            char[] separators = new char[] { ',', '-' };
            var input = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var customersByName = new SortedDictionary<string, Customer>();
            while (input[0] != "end of clients")
            {
                var customer = input[0];
                var product = input[1];
                var quantity = int.Parse(input[2]);

                if (pricesByProduct.ContainsKey(product))
                {
                    if (customersByName.ContainsKey(customer) == false)
                    {
                        customersByName[customer] = new Customer(customer);
                    }

                    customersByName[customer].Order(product, quantity, pricesByProduct[product]);
                }

                input = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var customer in customersByName)
            {
                Console.WriteLine($"{customer.Key}");
                foreach (var product in customer.Value.Orders)
                {
                    Console.WriteLine($"-- {product.Key} - {product.Value}");
                }

                Console.WriteLine($"Bill: {customer.Value.Bill:0.00}");
            }

            Console.WriteLine($"Total bill: {customersByName.Sum(cust => cust.Value.Bill):0.00}");
        }
    }

    internal class Customer
    {
        public Customer(string name)
        {
            this.Name = name;
            this.Orders = new Dictionary<string, int>();
        }

        public decimal Bill { get; private set; }

        public string Name { get; private set; }

        public Dictionary<string, int> Orders { get; set; }

        public void Order(string product, int quantity, decimal price)
        {
            if (this.Orders.ContainsKey(product) == false)
            {
                this.Orders[product] = 0;
            }

            this.Orders[product] += quantity;
            this.Bill += price * quantity;
        }
    }
}
