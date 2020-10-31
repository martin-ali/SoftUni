namespace _03_wild_farm.Models.Animals.Mammals.Felines
{
    using System;
    using _03_wild_farm.Models.Foods;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed) { }

        protected override Type[] allowedFoods { get; } = new Type[] { typeof(Meat), typeof(Vegetable) };

        protected override double WeightGainPerKgFood => 0.3;

        public override string MakeSound()
        {
            return "Meow";
        }
    }
}