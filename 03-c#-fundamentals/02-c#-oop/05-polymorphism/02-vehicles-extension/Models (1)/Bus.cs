namespace _02_vehicles_extension.Models
{
    using System;
    using _02_vehicles_extension.Interfaces;

    public class Bus : Vehicle, IVehicle
    {
        private const double AIR_CONDITIONER_DEFAULT_CONSUMPTION = 1.4;

        private bool airConditionerIsOn = true;

        public Bus(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionInLitersPerKm, tankCapacity) { }

        public string DriveEmpty(double kilometers)
        {
            this.airConditionerIsOn = false;
            return base.Drive(kilometers);
        }

        public override string Drive(double kilometers)
        {
            this.airConditionerIsOn = true;
            return base.Drive(kilometers);
        }

        public override double AirConditionerConsumptionInLitersPerKm
        {
            get
            {
                return this.airConditionerIsOn
                        ? AIR_CONDITIONER_DEFAULT_CONSUMPTION
                        : 0;
            }
        }
    }
}