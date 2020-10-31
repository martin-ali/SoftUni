using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;

namespace space_station.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            var goingAstronauts = new Queue<IAstronaut>(astronauts.Where(a => a.Oxygen > 0));
            var items = new Queue<string>(planet.Items);

            while (goingAstronauts.Any() && items.Any())
            {
                var astronaut = goingAstronauts.Peek();
                var item = items.Peek();

                if (astronaut.Oxygen > 0)
                {
                    astronaut.Bag.Items.Add(item);
                    astronaut.Breath();
                    items.Dequeue();

                    planet.Items.Remove(item);
                }
                else
                {
                    goingAstronauts.Dequeue();
                }
            }
        }
    }
}