namespace _03_wild_farm.Models.Animals.Birds
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        protected override string[] itemsToPrint
        {
            get
            {
                return new string[] {   this.Name.ToString(),
                                        this.WingSize.ToString(),
                                        this.Weight.ToString(),
                                        this.FoodEaten.ToString() };
            }
        }

        public double WingSize { get; }
    }
}