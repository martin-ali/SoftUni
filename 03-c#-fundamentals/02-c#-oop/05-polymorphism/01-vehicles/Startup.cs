namespace _01_vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using _01_vehicles.Interfaces;
    using _01_vehicles.Models;

    class Startup
    {
        // Wow. What. A. Mess.
        static void Main()
        {
            var vehicleByType = new Dictionary<string, IVehicle>();
            for (int i = 0; i < 2; i++)
            {
                var vehicle = CreateVehicle(Console.ReadLine().Split(' '));
                vehicleByType[vehicle.GetType().Name] = vehicle;
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
                    var vehicle = vehicleByType[type];
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

            Console.WriteLine(vehicleByType[nameof(Car)]);
            Console.WriteLine(vehicleByType[nameof(Truck)]);
        }

        private static IVehicle CreateVehicle(string[] parameters)
        {
            var vehicleType = parameters[0];
            var fuel = double.Parse(parameters[1]);
            var consumption = double.Parse(parameters[2]);

            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly
                        .GetTypes()
                        .First(t => t.Name == vehicleType);
            var constructor = type.GetConstructor(new Type[] { typeof(double), typeof(double) });

            IVehicle vehicle = null;
            vehicle = (IVehicle)constructor.Invoke(new object[] { fuel, consumption });

            return vehicle;
        }
    }
}
