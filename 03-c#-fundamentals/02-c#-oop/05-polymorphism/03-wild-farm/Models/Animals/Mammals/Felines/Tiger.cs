namespace _03_wild_farm.Models.Animals.Mammals.Felines
{
    using System;
    using _03_wild_farm.Models.Foods;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed) { }

        protected override Type[] allowedFoods { get; } = new Type[] { typeof(Meat) };

        protected override double WeightGainPerKgFood => 1;

        public override string MakeSound()
        {
            return "ROAR!!!";
        }
    }
}