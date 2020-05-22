using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using space_station.Models.Astronauts;
using space_station.Models.Mission;
using space_station.Models.Planets;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Utilities.Messages;

namespace space_station.Core
{
    public class Controller : IController
    {
        private List<IAstronaut> astronauts = new List<IAstronaut>();
        private List<IPlanet> planets = new List<IPlanet>();
        private IMission mission = new Mission();
        private int exploredPlanetsCount = 0;

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            switch (type)
            {
                case "Biologist": astronaut = new Biologist(astronautName); break;
                case "Geodesist": astronaut = new Geodesist(astronautName); break;
                case "Meteorologist": astronaut = new Meteorologist(astronautName); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            // TODO: >= vs >
            var astronauts = this.astronauts.Where(a => a.Oxygen > 60);

            if (astronauts.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            var planet = this.planets.Find(p => p.Name == planetName);

            this.mission.Explore(planet, astronauts.ToList());
            var deadAstronautsCount = this.astronauts.Count(a => a.CanBreath == false);
            this.exploredPlanetsCount++;

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronautsCount);
        }

        public string Report()
        {
            var report = new StringBuilder();

            report
            .AppendLine($"{exploredPlanetsCount} planets were explored!")
            .AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronauts)
            {
                var bagItems = astronaut.Bag.Items.Count == 0
                                ? "none"
                                : string.Join(", ", astronaut.Bag.Items);

                report
                .AppendLine($"Name: {astronaut.Name}")
                .AppendLine($"Oxygen: {astronaut.Oxygen}")
                .AppendLine($"Bag items: {bagItems}");
            }

            return report.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronauts.Find(a => a.Name == astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}