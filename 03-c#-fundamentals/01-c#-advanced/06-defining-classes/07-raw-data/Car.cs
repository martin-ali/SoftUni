namespace _07_raw_data
{
    public class Car
    {
        public Car(string model,
                    int engineSpeed, int enginePower,
                    int cargoWeight, string cargoType,
                    double tyre1Pressure, int tyre1Age,
                    double tyre2Pressure, int tyre2Age,
                    double tyre3Pressure, int tyre3Age,
                    double tyre4Pressure, int tyre4Age)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, Cargo.ParseType(cargoType));
            this.Tyre1 = new Tyre(tyre1Pressure, tyre1Age);
            this.Tyre2 = new Tyre(tyre2Pressure, tyre2Age);
            this.Tyre3 = new Tyre(tyre3Pressure, tyre3Age);
            this.Tyre4 = new Tyre(tyre4Pressure, tyre4Age);
            this.Tyres = new[] { Tyre1, Tyre2, Tyre3, Tyre4 };
        }

        public string Model { get; private set; }

        public Engine Engine { get; private set; }

        public Cargo Cargo { get; private set; }

        public Tyre Tyre1 { get; private set; }

        public Tyre Tyre2 { get; private set; }

        public Tyre Tyre3 { get; private set; }

        public Tyre Tyre4 { get; private set; }

        public Tyre[] Tyres { get; set; }

        public override string ToString()
        {
            return this.Model;
        }
    }
}