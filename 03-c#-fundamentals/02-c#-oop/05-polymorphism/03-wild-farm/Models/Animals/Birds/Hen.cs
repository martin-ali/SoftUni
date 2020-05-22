namespace _03_wild_farm.Models.Animals.Birds
{
    using System;
    using _03_wild_farm.Models.Foods;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize) { }

        protected override Type[] allowedFoods { get; } = new Type[] { typeof(Food) };

        protected override double WeightGainPerKgFood => 0.35;

        public override string MakeSound()
        {
            return "Cluck";
        }
    }
}