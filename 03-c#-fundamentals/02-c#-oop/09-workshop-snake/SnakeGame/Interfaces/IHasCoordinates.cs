using SnakeGame.Models;

namespace SnakeGame.Interfaces
{
    public interface IHasCoordinates
    {
        Point Coordinates { get; }
    }
}