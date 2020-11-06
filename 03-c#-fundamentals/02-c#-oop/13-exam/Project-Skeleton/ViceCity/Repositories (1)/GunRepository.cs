namespace ViceCity.Repositories
{
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> models = new List<IGun>();

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            if (this.models.Contains(model) == false)
            {
                this.models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return this.models.Find(g => g.Name == name);
        }

        public bool Remove(IGun model)
        {
            return this.models.Remove(model);
        }
    }
}