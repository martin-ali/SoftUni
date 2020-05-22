namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private char foodSymbol;

        private Random random;

        private Wall wall;

        public Food(Wall wall, char foodSymbol, int points)
            : base(wall.X, wall.Y)
        {
            this.wall = wall;
            this.FoodPoints = points;
            this.foodSymbol = foodSymbol;
            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snake)
        {
            var newX = this.random.Next(2, wall.X - 2);
            var newY = this.random.Next(2, wall.Y - 2);


            var isPointOfSnake = snake.Any(segment => segment.X == newX && segment.Y == newY);
            while (isPointOfSnake)
            {
                newX = this.random.Next(2, wall.X - 2);
                newY = this.random.Next(2, wall.Y - 2);

                isPointOfSnake = snake.Any(segment => segment.X == newX && segment.Y == newY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(this.foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.X == this.X
                && snake.Y == this.Y;
        }
    }
}