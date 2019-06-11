using System;
using System.Collections.Generic;

namespace _08_car_salesman
{
    class StartUp
    {
        static void Main()
        {
            var engineByModel = new Dictionary<string, Engine>();
            var engineCount = int.Parse(Console.ReadLine());
            for (int current = 0; current < engineCount; current++)
            {
                var engineData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var model = engineData[0];
                var power = int.Parse(engineData[1]);
                var displacement = default(int);
                var efficiency = default(string);

                if (engineData.Length == 4)
                {
                    displacement = int.Parse(engineData[2]);
                    efficiency = engineData[3];
                }
                else if (engineData.Length == 3 && int.TryParse(engineData[2], out displacement))
                { }
                else if (engineData.Length == 3)
                {
                    efficiency = engineData[2];
                }

                engineByModel[model] = new Engine(model, power, displacement, efficiency);
            }

            var carCount = int.Parse(Console.ReadLine());
            for (int current = 0; current < carCount; current++)
            {
                var carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var model = carData[0];
                var engineModel = carData[1];
                var engine = engineByModel[engineModel];
                var weight = default(int);
                var color = default(string);


                if (carData.Length == 4)
                {
                    weight = int.Parse(carData[2]);
                    color = carData[3];
                }
                else if (carData.Length == 3 && int.TryParse(carData[2], out weight))
                { }
                else if (carData.Length == 3)
                {
                    color = carData[2];
                }

                var car = new Car(model, engine, weight, color);
                Console.WriteLine(car);
            }
        }
    }
}
