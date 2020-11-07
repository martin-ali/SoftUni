namespace space_station.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const int DEFAULT_OXYGEN = 90;

        public Meteorologist(string name)
            : base(name, DEFAULT_OXYGEN)
        { }
    }
}