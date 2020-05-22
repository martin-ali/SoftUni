namespace Restaurant
{
    public class Fish : MainDish
    {
        public Fish(string name, decimal price, double grams) : base(name, price, grams) { }

        public Fish(string name, decimal price) : base(name, price, 22) { }
    }
}