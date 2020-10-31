namespace SnakeGame.Models
{
    using SnakeGame.Interfaces;

    public class Snake : IRenderable, IHasCoordinates
    {
        public Snake(Point coordinates)
        {
            this.Coordinates = coordinates;
        }

        public Point Coordinates { get; }
    }
}