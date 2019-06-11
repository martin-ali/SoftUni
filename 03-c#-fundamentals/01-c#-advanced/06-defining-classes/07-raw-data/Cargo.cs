using System;

namespace _07_raw_data
{
    public enum CargoType { Flammable, Fragile };

    public class Cargo
    {
        public Cargo(int weight, CargoType type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public int Weight { get; private set; }

        public CargoType Type { get; private set; }

        internal static CargoType ParseType(string cargoType)
        {
            return cargoType == "fragile" ? CargoType.Fragile : CargoType.Flammable;
        }
    }
}