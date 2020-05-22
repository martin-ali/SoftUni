namespace _07_food_shortage.Models
{
    using _07_food_shortage.Interfaces;

    public class Rebel : INamed, IHasAge, IBuyer
    {
        private const int REBEL_FOOD_RATION = 5;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; }

        public int Age { get; }

        public string Group { get; }

        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            this.Food += REBEL_FOOD_RATION;
        }
    }
}