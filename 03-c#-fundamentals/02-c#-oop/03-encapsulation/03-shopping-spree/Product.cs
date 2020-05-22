namespace _03_shopping_spree
{
    public class Product
    {
        private string name;

        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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

        public decimal Cost
        {
            get => cost;

            private set
            {
                Validator.ThrowIfMoneyIsInvalid(value);

                cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}