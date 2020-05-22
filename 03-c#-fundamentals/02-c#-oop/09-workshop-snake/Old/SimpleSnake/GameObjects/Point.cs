namespace SimpleSnake.GameObjects
{
    using System;

    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        // FIXME: Put into Renderer Class
        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.WriteLine(symbol);
        }

        public void Draw(int left, int top, char symbol)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(symbol);
        }
    }
}