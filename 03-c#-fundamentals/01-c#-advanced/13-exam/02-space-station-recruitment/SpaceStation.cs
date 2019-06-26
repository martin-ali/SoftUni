using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.data = new List<Astronaut>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Astronaut astronaut)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            var astronautsRemoved = this.data.RemoveAll(a => a.Name == name);

            return astronautsRemoved > 0;
        }

        public Astronaut GetOldestAstronaut()
        {
            return this.data.OrderByDescending(a => a.Age).First();
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.data.First(a => a.Name == name);
        }

        public string Report()
        {
            var report = $"Astronauts working at Space Station {this.Name}:";

            foreach (var astronaut in this.data)
            {
                report += $"{Environment.NewLine}{astronaut}";
            }

            return report;
        }
    }
}