namespace _03_wild_farm.Models.Animals.Birds
{
    using System;
    using _03_wild_farm.Models.Foods;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize) { }

        protected override Type[] allowedFoods { get; } = new Type[] { typeof(Meat) };

        protected override double WeightGainPerKgFood => 0.25;

        public override string MakeSound()
        {
            return "Hoot Hoot";
        }
    }
}