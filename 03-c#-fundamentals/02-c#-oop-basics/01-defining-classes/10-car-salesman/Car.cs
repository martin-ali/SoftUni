using System;
using System.Collections.Generic;

namespace _10_car_salesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        : this(model, engine, Constants.Missing, Constants.Missing)
        {
        }

        public Car(string model, Engine engine, string weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; }

        public Engine Engine { get; }

        public string Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            var text =
            $"{this.Model}:{Environment.NewLine}" +
            $"{this.Engine}" +
            $"  Weight: {this.Weight}{Environment.NewLine}" +
            $"  Color: {this.Color}";

            return text;
        }

        internal static Car Parse(string input, Dictionary<string, Engine> engineCatalogue)
        {
            var data = new Queue<string>(input.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            var model = data.Dequeue();
            var engine = engineCatalogue[data.Dequeue()];

            var car = new Car(model, engine);

            if (data.Count > 0)
            {
                if (int.TryParse(data.Peek(), out int weight))
                {
                    car.Weight = data.Dequeue();
                }
                else
                {
                    car.Color = data.Dequeue();
                }
            }
            if (data.Count > 0)
            {
                car.Color = data.Dequeue();
            }

            return car;
        }
    }
}