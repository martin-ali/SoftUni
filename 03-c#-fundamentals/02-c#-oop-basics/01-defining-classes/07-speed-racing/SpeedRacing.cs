using System;
using System.Collections.Generic;

namespace _07_speed_racing
{
    class SpeedRacing
    {
        static void Main()
        {
            var carsByModel = new Dictionary<string, Car>();
            var carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                var data = Console.ReadLine().Split();
                var model = data[0];
                var fuelAmount = double.Parse(data[1]);
                var fuelConsumptionPerKm = double.Parse(data[2]);

                var car = new Car(model, fuelAmount, fuelConsumptionPerKm);
                carsByModel[model] = car;
            }

            var input = Console.ReadLine();
            while (input != "End")
            {
                var data = input.Split();
                var model = data[1];
                var distance = double.Parse(data[2]);

                try
                {
                    carsByModel[model].Drive(distance);
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var car in carsByModel)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:0.00} {car.Value.KmTraveled}");
            }
        }
    }
}
