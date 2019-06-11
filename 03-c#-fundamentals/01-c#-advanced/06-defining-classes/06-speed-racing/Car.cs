using System;

namespace _06_speed_racing
{
    public class Car
    {
        public Car(string model, double fuel, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.Fuel = fuel;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public string Model { get; private set; }

        public double Fuel { get; private set; }

        public double FuelConsumptionPerKilometer { get; private set; }

        public int KilometersTraveled { get; private set; } = 0;

        public void Drive(int kilometers)
        {
            var fuelRequired = kilometers * this.FuelConsumptionPerKilometer;
            if (fuelRequired > this.Fuel)
            {
                throw new ArgumentException("Insufficient fuel for the drive");
            }

            this.Fuel -= fuelRequired;
            this.KilometersTraveled += kilometers;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.Fuel:0.00} {this.KilometersTraveled}";
        }
    }
}
