using System;
using System.Collections.Generic;

namespace _06_speed_racing
{
    class StartUp
    {
        static void Main()
        {
            var carByModel = new Dictionary<string, Car>();

            var carsCount = int.Parse(Console.ReadLine());
            for (int current = 0; current < carsCount; current++)
            {
                var carData = Console.ReadLine().Split();
                var model = carData[0];
                var fuel = double.Parse(carData[1]);
                var fuelConsumptionPerKilometer = double.Parse(carData[2]);

                var car = new Car(model, fuel, fuelConsumptionPerKilometer);
                carByModel[model] = car;
            }

            var input = Console.ReadLine();
            while (input != "End")
            {
                var parameters = input.Split();
                var model = parameters[1];
                var kilometers = int.Parse(parameters[2]);

                try
                {
                    carByModel[model].Drive(kilometers);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var car in carByModel)
            {
                Console.WriteLine(car.Value);
            }
        }
    }
}

/*

2
AudiA4 23 0.3
BMW-M2 45 0.42
Drive BMW-M2 56
Drive AudiA4 5
Drive AudiA4 13
End

3
AudiA4 18 0.34
BMW-M2 33 0.41
Ferrari-488Spider 50 0.47
Drive Ferrari-488Spider 97
Drive Ferrari-488Spider 35
Drive AudiA4 85
Drive AudiA4 50
End

*/
