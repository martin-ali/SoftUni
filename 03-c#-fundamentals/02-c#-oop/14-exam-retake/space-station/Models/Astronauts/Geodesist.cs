namespace space_station.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const int DEFAULT_OXYGEN = 50;

        public Geodesist(string name)
            : base(name, DEFAULT_OXYGEN)
        { }
    }
}