namespace _03_wild_farm.Models.Animals.Mammals
{
    using System;
    using _03_wild_farm.Models.Foods;

    public class Mouse : NeedsAName
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion) { }

        protected override Type[] allowedFoods { get; } = new Type[] { typeof(Vegetable), typeof(Fruit) };

        protected override double WeightGainPerKgFood => 0.1;

        public override string MakeSound()
        {
            return "Squeak";
        }
    }
}