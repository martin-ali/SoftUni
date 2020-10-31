namespace _02_vehicles_extension.Models
{
    using _02_vehicles_extension.Interfaces;

    public class Truck : Vehicle, IVehicle
    {
        private const double AIR_CONDITIONER_DEFAULT_CONSUMPTION = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionInLitersPerKm, tankCapacity) { }

        public override double AirConditionerConsumptionInLitersPerKm { get; } = AIR_CONDITIONER_DEFAULT_CONSUMPTION;

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            var leakedFuel = liters * 0.05;
            this.fuelQuantity -= leakedFuel;
        }
    }
}