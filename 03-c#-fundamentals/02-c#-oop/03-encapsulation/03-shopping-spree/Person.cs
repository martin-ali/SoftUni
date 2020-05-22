namespace _03_shopping_spree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;

        private decimal money;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get => name;

            private set
            {
                Validator.ThrowIfNameIsInvalid(value);

                name = value;
            }
        }

        public decimal Money
        {
            get => money;

            private set
            {
                Validator.ThrowIfMoneyIsInvalid(value);

                money = value;
            }
        }

        public List<Product> Products { get; private set; } = new List<Product>();

        public string Buy(Product product)
        {
            if (product.Cost > this.Money)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.Products.Add(product);
            this.Money -= product.Cost;

            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            var purchaseHistory = $"{this.Name} - ";

            if (this.Products.Count > 0)
            {
                purchaseHistory += string.Join(", ", this.Products);
            }
            else
            {
                purchaseHistory += "Nothing bought";
            }

            return purchaseHistory;
        }
    }
}