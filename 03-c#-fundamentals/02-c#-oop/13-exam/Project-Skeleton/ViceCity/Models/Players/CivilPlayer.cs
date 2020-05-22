namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        private const int DEFAULT_LIFE_POINTS = 50;

        public CivilPlayer(string name)
            : base(name, DEFAULT_LIFE_POINTS)
        { }
    }
}