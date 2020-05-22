namespace _01_vehicles.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumptionInLitersPerKm { get; }

        string Drive(double kilometers);

        void Refuel(double liters);
    }
}