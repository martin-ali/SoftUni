using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_raw_data
{
    class RawData
    {
        private const string Fragile = "fragile";

        private const string Flammable = "flamable";

        static void Main()
        {
            var carByModel = new Dictionary<string, Car>();
            var carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                var data = Console.ReadLine().Split();
                var model = data[0];
                var engine = new Engine(int.Parse(data[1]), int.Parse(data[2]));
                var cargo = new Cargo(int.Parse(data[3]), data[4]);
                var tyre1 = new Tyre(double.Parse(data[5]), int.Parse(data[6]));
                var tyre2 = new Tyre(double.Parse(data[7]), int.Parse(data[8]));
                var tyre3 = new Tyre(double.Parse(data[9]), int.Parse(data[10]));
                var tyre4 = new Tyre(double.Parse(data[11]), int.Parse(data[12]));

                var car = new Car(model, engine, cargo, new Tyre[] { tyre1, tyre2, tyre3, tyre4 });
                carByModel[model] = car;
            }

            var filter = Console.ReadLine();

            var filteredCars = carByModel.Values.Where(c => c.Cargo.Type == filter);
            if (filter == Fragile)
            {
                filteredCars = filteredCars.Where(c => c.Tyres.Any(t => t.Pressure < 1));
            }
            else if (filter == Flammable)
            {
                filteredCars = filteredCars.Where(c => c.Engine.Power > 250);
            }

            foreach (var car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
