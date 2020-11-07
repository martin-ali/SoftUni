namespace SnakeGame.Models.Food
{
    using SnakeGame.Interfaces;

    public abstract class Food : IFood, IRenderable, IHasCoordinates
    {
        public Point Coordinates => throw new System.NotImplementedException();
    }
}