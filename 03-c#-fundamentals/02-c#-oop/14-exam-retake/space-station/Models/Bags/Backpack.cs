using System.Collections.Generic;
using SpaceStation.Models.Bags;

namespace space_station.Models.Bags
{
    public class Backpack : IBag
    {
        public Backpack()
        {
            this.Items = new List<string>();
        }

        public ICollection<string> Items { get; }
    }
}