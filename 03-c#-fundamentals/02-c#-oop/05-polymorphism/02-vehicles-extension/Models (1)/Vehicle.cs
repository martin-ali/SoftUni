namespace _02_vehicles_extension.Models
{
    using System;
    using _02_vehicles_extension.Interfaces;

    public abstract class Vehicle : IVehicle
    {
        protected double fuelQuantity = 0;

        public Vehicle(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
        {
            if (fuelQuantity <= tankCapacity)
            {
                this.fuelQuantity = fuelQuantity;
            }

            this.FuelConsumptionInLitersPerKm = fuelConsumptionInLitersPerKm;
            this.TankCapacity = tankCapacity;
        }

        public virtual double AirConditionerConsumptionInLitersPerKm { get; } = 0;

        public double FuelConsumptionInLitersPerKm { get; }

        public double TankCapacity { get; }

        public virtual string Drive(double kilometers)
        {
            var fuelConsumption = this.FuelConsumptionInLitersPerKm
                    + this.AirConditionerConsumptionInLitersPerKm;
            var fuelConsumed = fuelConsumption * kilometers;

            if (fuelConsumed > this.fuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.fuelQuantity -= fuelConsumed;

            return $"{this.GetType().Name} travelled {kilometers} km";
        }

        public virtual void Refuel(double liters)
        {
            var spaceUsed = this.fuelQuantity + liters;
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (spaceUsed > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            this.fuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.fuelQuantity:0.00}";
        }
    }
}