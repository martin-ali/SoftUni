using System;
using System.Collections.Generic;

namespace _10_car_salesman
{
    public class Engine
    {
        public Engine(string model, int power)
        : this(model, power, Constants.Missing, Constants.Missing)
        {
        }

        public Engine(string model, int power, string displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; }

        public int Power { get; }

        public string Displacement { get; set; }

        public string Efficiency { get; set; }

        public static Engine Parse(string input)
        {
            var data = new Queue<string>(input.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            var model = data.Dequeue();
            var power = int.Parse(data.Dequeue());

            var engine = new Engine(model, power);

            if (data.Count > 0)
            {
                if (int.TryParse(data.Peek(), out int displacement))
                {
                    engine.Displacement = data.Dequeue();
                }
                else
                {
                    engine.Efficiency = data.Dequeue();
                }
            }
            if (data.Count > 0)
            {
                engine.Efficiency = data.Dequeue();
            }

            return engine;
        }

        public override string ToString()
        {
            var text =
            $"  {this.Model}:{Environment.NewLine}" +
            $"    Power: {this.Power}{Environment.NewLine}" +
            $"    Displacement: {this.Displacement}{Environment.NewLine}" +
            $"    Efficiency: {this.Efficiency}{Environment.NewLine}";

            return text;
        }
    }
}