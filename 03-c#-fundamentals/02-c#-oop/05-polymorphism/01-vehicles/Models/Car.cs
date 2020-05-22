namespace _01_vehicles.Models
{
    using _01_vehicles.Interfaces;

    public class Car : Vehicle, IVehicle
    {
        private const double AIR_CONDITIONER_DEFAULT_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionInLitersPerKm)
            : base(fuelQuantity, fuelConsumptionInLitersPerKm, AIR_CONDITIONER_DEFAULT_CONSUMPTION)
        { }
    }
}