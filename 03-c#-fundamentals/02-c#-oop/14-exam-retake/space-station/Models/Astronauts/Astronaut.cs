using System;
using space_station.Models.Bags;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;

namespace space_station.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private const int OXYGEN_CONSUMPTION = 10;
        private string name;
        private double oxygen;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                this.name = value;
            }
        }
        public double Oxygen
        {
            get => this.oxygen;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        // TODO: Implement
        public bool CanBreath { get => this.Oxygen > 0; }

        public IBag Bag { get; }

        // TODO: Inspect later
        public virtual void Breath()
        {
            var oxygen = this.Oxygen - OXYGEN_CONSUMPTION;

            if (oxygen < 0)
            {
                oxygen = 0;
            }

            this.Oxygen = oxygen;
        }
    }
}