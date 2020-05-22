namespace _03_wild_farm.Models.Animals.Mammals
{
    using System;
    using _03_wild_farm.Models.Foods;

    public class Dog : NeedsAName
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion) { }

        protected override Type[] allowedFoods { get; } = new Type[] { typeof(Meat) };

        protected override double WeightGainPerKgFood => 0.4;

        public override string MakeSound()
        {
            return "Woof!";
        }
    }
}