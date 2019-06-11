using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;

        private List<Car> cars;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>(capacity);
        }

        public int Count
        {
            get
            {
                return this.cars.Count;
            }
        }

        public string AddCar(Car car)
        {
            if (this.cars.Exists(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count >= this.capacity)
            {
                return "Parking is full!";
            }

            this.cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            var carHasBeenRemoved = this.cars.RemoveAll(c => c.RegistrationNumber == registrationNumber) > 0;

            if (carHasBeenRemoved)
            {
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            var car = this.cars.Find(c => c.RegistrationNumber == registrationNumber);

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            this.cars.RemoveAll(c => registrationNumbers.Contains(c.RegistrationNumber));
        }
    }
}