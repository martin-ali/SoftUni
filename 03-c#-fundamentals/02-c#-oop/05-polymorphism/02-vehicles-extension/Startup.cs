namespace _02_vehicles_extension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using _02_vehicles_extension.Interfaces;
    using _02_vehicles_extension.Models;

    class Startup
    {
        // Still pretty messy
        static void Main()
        {
            var vehicles = new List<IVehicle>();
            for (int i = 0; i < 3; i++)
            {
                var vehicle = CreateVehicle(Console.ReadLine().Split(' '));
                vehicles.Add(vehicle);
            }

            var commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                var vehicleData = Console.ReadLine().Split(' ');
                var command = vehicleData[0];
                var type = vehicleData[1];
                var parameter = double.Parse(vehicleData[2]);

                try
                {
                    var vehicle = vehicles.Find(v => v.GetType().Name == type);
                    var method = vehicle.GetType().GetMethod(command);
                    var result = method.Invoke(vehicle, new object[] { parameter });

                    if (result != null)
                    {
                        Console.WriteLine(result);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.InnerException.Message);
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private static IVehicle CreateVehicle(string[] parameters)
        {
            var vehicleType = parameters[0];
            var fuel = double.Parse(parameters[1]);
            var consumption = double.Parse(parameters[2]);
            var tankCapacity = double.Parse(parameters[3]);

            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly
                        .GetTypes()
                        .First(t => t.Name == vehicleType);
            var constructor = type.GetConstructor(new Type[] { typeof(double), typeof(double), typeof(double) });

            IVehicle vehicle = null;
            vehicle = (IVehicle)constructor.Invoke(new object[] { fuel, consumption, tankCapacity });

            return vehicle;
        }
    }
}
/*

Car 30 0.04 70
Truck 100 0.5 300
Bus 40 0.3 150
8
Refuel Car -10
Refuel Truck 0
Refuel Car 10
Refuel Car 300
Drive Bus 10
Refuel Bus 1000
DriveEmpty Bus 100
Refuel Truck 1000

Car 300 0.04 70
Truck 100 0.5 300
Bus 400 0.3 1500
2
Refuel Truck 100
Drive Bus 100

*/
