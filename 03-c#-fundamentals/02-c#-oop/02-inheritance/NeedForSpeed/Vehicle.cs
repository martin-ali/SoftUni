namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.DefaultFuelConsumption = this.FuelConsumption;
        }

        public double DefaultFuelConsumption { get; private set; }

        public virtual double FuelConsumption { get; protected set; } = 1.25;

        public int HorsePower { get; private set; }

        public double Fuel { get; private set; }

        public virtual void Drive(double kilometers)
        {
            var fuelUsed = this.DefaultFuelConsumption * kilometers;

            this.Fuel -= fuelUsed;
        }
    }
}