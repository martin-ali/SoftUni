namespace _02_vehicles_extension.Interfaces
{
    public interface IVehicle
    {
        double FuelConsumptionInLitersPerKm { get; }

        string Drive(double kilometers);

        void Refuel(double liters);
    }
}