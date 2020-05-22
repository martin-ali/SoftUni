namespace _03_wild_farm.Models.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        protected override string[] itemsToPrint
        {
            get
            {
                return new string[] {   this.Name.ToString(),
                                        this.Breed.ToString(),
                                        this.Weight.ToString(),
                                        this.LivingRegion.ToString(),
                                        this.FoodEaten.ToString() };
            }
        }

        public string Breed { get; }
    }
}