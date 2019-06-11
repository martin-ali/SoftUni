using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_raw_data
{
    class StartUp
    {
        static void Main()
        {
            var carCount = int.Parse(Console.ReadLine());
            var cars = new Car[carCount];
            for (int current = 0; current < carCount; current++)
            {
                var carData = Console.ReadLine().Split();
                var model = carData[0];
                var engineSpeed = int.Parse(carData[1]);
                var enginePower = int.Parse(carData[2]);
                var cargoWeight = int.Parse(carData[3]);
                var cargoType = carData[4];
                var tyre1Pressure = double.Parse(carData[5]);
                var tyre1Age = int.Parse(carData[6]);
                var tyre2Pressure = double.Parse(carData[7]);
                var tyre2Age = int.Parse(carData[8]);
                var tyre3Pressure = double.Parse(carData[9]);
                var tyre3Age = int.Parse(carData[10]);
                var tyre4Pressure = double.Parse(carData[11]);
                var tyre4Age = int.Parse(carData[12]);

                var car = new Car
                (
                    model,
                    engineSpeed, enginePower,
                    cargoWeight, cargoType,
                    tyre1Pressure, tyre1Age,
                    tyre2Pressure, tyre2Age,
                    tyre3Pressure, tyre3Age,
                    tyre4Pressure, tyre4Age
                );

                cars[current] = car;
            }

            IEnumerable<Car> filteredCars;
            var cargoTypeToFilter = Console.ReadLine();
            if (cargoTypeToFilter == "fragile")
            {
                filteredCars = cars
                                .Where(c => c.Cargo.Type == CargoType.Fragile)
                                .Where(c => c.Tyres.Any(t => t.Pressure < 1));

            }
            else
            {
                filteredCars = cars
                                .Where(c => c.Cargo.Type == CargoType.Flammable)
                                .Where(c => c.Engine.Power > 250);
            }

            foreach (var car in filteredCars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
