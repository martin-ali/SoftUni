namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WALL_SYMBOL = '\u25A0';

        public Wall(int left, int top)
            : base(left, top)
        {
            this.InitializeWallBorders();
        }

        private void InitializeWallBorders()
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.Y);

            this.SetVerticalLine(0);
            this.SetVerticalLine(this.X - 1);
        }

        private void SetHorizontalLine(int top)
        {
            for (int left = 0; left < this.X; left++)
            {
                this.Draw(left, top, WALL_SYMBOL);
            }
        }

        private void SetVerticalLine(int left)
        {
            for (int top = 0; top < this.Y; top++)
            {
                this.Draw(left, top, WALL_SYMBOL);
            }
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.Y == 0
                || snake.X == 0
                || snake.X == this.X - 1
                || snake.Y == this.Y;
        }
    }
}