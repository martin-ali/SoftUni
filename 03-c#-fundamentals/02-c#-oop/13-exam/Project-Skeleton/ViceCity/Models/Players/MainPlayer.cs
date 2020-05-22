namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const int DEFAULT_LIFE_POINTS = 100;
        private const string DEFAULT_NAME = "Tommy Vercetti";

        public MainPlayer()
            : base(DEFAULT_NAME, DEFAULT_LIFE_POINTS)
        { }
    }
}