using System;

namespace _07_speed_racing
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.KmTraveled = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public double KmTraveled { get; set; }

        public void Drive(double distanceInKm)
        {
            var fuelNeeded = distanceInKm * this.FuelConsumptionPerKm;
            if (fuelNeeded > FuelAmount)
            {
                throw new InvalidOperationException("Insufficient fuel for the drive");
            }

            this.FuelAmount -= fuelNeeded;
            this.KmTraveled += distanceInKm;
        }
    }
}
