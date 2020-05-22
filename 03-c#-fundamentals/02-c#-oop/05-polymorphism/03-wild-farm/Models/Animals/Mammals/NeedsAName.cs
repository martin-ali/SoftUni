namespace _03_wild_farm.Models.Animals.Mammals
{
    public abstract class NeedsAName : Mammal
    {
        protected NeedsAName(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion) { }

        protected override string[] itemsToPrint
        {
            get
            {
                return new string[] {   this.Name.ToString(),
                                         this.Weight.ToString(),
                                         this.LivingRegion.ToString(),
                                         this.FoodEaten.ToString() };
            }
        }
    }
}