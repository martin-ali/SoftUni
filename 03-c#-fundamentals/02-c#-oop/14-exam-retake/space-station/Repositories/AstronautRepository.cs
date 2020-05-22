using System.Collections.Generic;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace space_station.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        // TODO: Could be replaced with Dictionary?
        private List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models
        {
            get
            {
                return this.astronauts.AsReadOnly();
            }
        }

        public void Add(IAstronaut model)
        {
            this.astronauts.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return this.astronauts.Find(a => a.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            return this.astronauts.Remove(model);
        }
    }
}