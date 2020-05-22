namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name, decimal price = 5, double grams = 250, double calories = 1000) : base(name, price, grams, calories) { }

        public Cake(string name) : base(name, 5, 250, 1000) { }
    }
}