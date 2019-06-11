namespace _08_car_salesman
{
    public class Car
    {
        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine, weight, default(string)) { }

        public Car(string model, Engine engine, string color) : this(model, engine, default(int), color) { }

        public Car(string model, Engine engine) : this(model, engine, default(int), default(string)) { }

        public string Model { get; private set; }

        public Engine Engine { get; private set; }

        public int Weight { get; private set; }

        public string Color { get; private set; }

        public override string ToString()
        {
            var weight = this.Weight == default(int) ? "n/a" : this.Weight.ToString();
            var color = this.Color == default(string) ? "n/a" : this.Color;

            return $"{this.Model}:\n{this.Engine}\n  Weight: {weight}\n  Color: {color}";
        }
    }
}
