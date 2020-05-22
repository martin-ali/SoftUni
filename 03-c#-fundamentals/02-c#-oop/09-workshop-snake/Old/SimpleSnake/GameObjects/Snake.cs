namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake
    {
        private const char snakeSymbol = '\u25CF';

        private char emptySpace = ' ';

        private Queue<Point> snakeElements = new Queue<Point>();

        private List<Food> food = new List<Food>();

        private Wall wall;

        private int nextX;

        private int nextY;

        private int foodIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.foodIndex = RandomFoodNumber;
            this.GetFoods();
            this.CreateSnake();
        }

        public int RandomFoodNumber => new Random().Next(0, this.food.Count);

        public void CreateSnake()
        {
            for (int y = 1; y <= 6; y++)
            {
                this.snakeElements.Enqueue(new Point(2, y));
            }
        }

        private void GetFoods()
        {
            this.food.Add(new FoodHash(this.wall));
            this.food.Add(new FoodDollar(this.wall));
            this.food.Add(new FoodAsterisk(this.wall));
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextX = snakeHead.X + direction.X;
            this.nextY = snakeHead.Y + direction.Y;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            var length = food[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextX, this.nextY));
                GetNextPoint(direction, currentSnakeHead);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.food[foodIndex].SetRandomPosition(this.snakeElements);
        }

        public bool IsMoving(Point direction)
        {
            var currentSnakeHead = this.snakeElements.Last();

            this.GetNextPoint(direction, currentSnakeHead);

            var isPointOfSnake = this.snakeElements.Any(s => s.X == this.nextX && s.Y == this.nextY);

            if (isPointOfSnake)
            {
                return false;
            }

            var snakeNewHead = new Point(this.nextX, this.nextY);

            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (food[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            var snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(emptySpace);

            return true;
        }
    }
}