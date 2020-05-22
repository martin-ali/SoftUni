namespace SimpleSnake.GameObjects
{
    public class FoodHash : Food
    {
        private const char foodSymbol = '*';

        private const int points = 1;

        public FoodHash(Wall wall)
            : base(wall, foodSymbol, points) { }
    }
}