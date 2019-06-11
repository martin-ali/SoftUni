namespace _08_car_salesman
{
    public class Engine
    {
        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement) : this(model, power, displacement, default(string)) { }

        public Engine(string model, int power, string efficiency) : this(model, power, default(int), efficiency) { }

        public Engine(string model, int power) : this(model, power, default(int), default(string)) { }

        public string Model { get; private set; }

        public int Power { get; private set; }

        public int Displacement { get; private set; }

        public string Efficiency { get; private set; }

        public override string ToString()
        {
            var displacement = this.Displacement == default(int) ? "n/a" : this.Displacement.ToString();
            var efficiency = this.Efficiency == default(string) ? "n/a" : this.Efficiency;

            return $"  {this.Model}:\n    Power: {this.Power}\n    Displacement: {displacement}\n    Efficiency: {efficiency}";
        }
    }
}
