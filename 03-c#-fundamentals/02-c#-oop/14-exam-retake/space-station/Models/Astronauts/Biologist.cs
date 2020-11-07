namespace space_station.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int DEFAULT_OXYGEN = 70;
        private const int OXYGEN_CONSUMPTION = 5;

        public Biologist(string name)
            : base(name, DEFAULT_OXYGEN)
        { }

        public override void Breath()
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