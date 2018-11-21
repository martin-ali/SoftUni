namespace _08_raw_data
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tyre[] tyres)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tyres = tyres;
        }

        public string Model { get; }

        public Engine Engine { get; }

        public Cargo Cargo { get; }

        public Tyre[] Tyres { get; }
    }
}