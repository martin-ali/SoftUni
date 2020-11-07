namespace _01_vehicles.Models
{
    using System;
    using _01_vehicles.Interfaces;

    public class Vehicle : IVehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionInLitersPerKm, double airConditionerConsumptionInLitersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionInLitersPerKm = fuelConsumptionInLitersPerKm;
            this.AirConditionerConsumptionInLitersPerKm = airConditionerConsumptionInLitersPerKm;
        }

        public double FuelConsumptionInLitersPerKm { get; }

        public double AirConditionerConsumptionInLitersPerKm { get; }

        public double FuelQuantity { get; protected set; }

        public virtual string Drive(double kilometers)
        {
            var fuelConsumption = this.FuelConsumptionInLitersPerKm
                    + this.AirConditionerConsumptionInLitersPerKm;
            var fuelConsumed = fuelConsumption * kilometers;

            if (fuelConsumed > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= fuelConsumed;

            return $"{this.GetType().Name} travelled {kilometers} km";
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:0.00}";
        }
    }
}