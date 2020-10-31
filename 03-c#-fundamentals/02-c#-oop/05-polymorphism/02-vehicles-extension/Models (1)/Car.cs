namespace _02_vehicles_extension.Models
{
    using _02_vehicles_extension.Interfaces;

    public class Car : Vehicle, IVehicle
    {
        private const double AIR_CONDITIONER_DEFAULT_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionInLitersPerKm, tankCapacity) { }

        public override double AirConditionerConsumptionInLitersPerKm { get; } = AIR_CONDITIONER_DEFAULT_CONSUMPTION;
    }
}