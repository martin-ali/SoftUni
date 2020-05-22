namespace _01_vehicles.Models
{
    using _01_vehicles.Interfaces;

    public class Truck : Vehicle, IVehicle
    {
        private const double AIR_CONDITIONER_DEFAULT_CONSUMPTION = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionInLitersPerKm)
            : base(fuelQuantity, fuelConsumptionInLitersPerKm, AIR_CONDITIONER_DEFAULT_CONSUMPTION)
        { }

        public override void Refuel(double liters)
        {
            var keptFuel = liters * 0.95;
            this.FuelQuantity += keptFuel;
        }
    }
}