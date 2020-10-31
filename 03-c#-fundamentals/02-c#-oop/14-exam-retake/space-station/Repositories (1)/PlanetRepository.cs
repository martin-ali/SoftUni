using System.Collections.Generic;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;

namespace space_station.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {

        private List<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
        {
            get
            {
                return this.planets.AsReadOnly();
            }
        }

        public void Add(IPlanet model)
        {
            this.planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.planets.Find(a => a.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return this.planets.Remove(model);
        }
    }
}