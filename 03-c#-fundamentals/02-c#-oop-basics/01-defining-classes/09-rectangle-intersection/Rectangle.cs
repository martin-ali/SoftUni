using System;

namespace _09_rectangle_intersection
{
    public class Rectangle
    {
        public Rectangle(string id, int width, int height, Point coordinates)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.Coordinates = coordinates;
        }

        public string Id { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public Point Coordinates { get; set; }

        public bool DoesItIntersect(Rectangle other)
        {
            // WTF
            // It's 23:35, can't think
            double otherX1 = other.Coordinates.X;
            double otherX2 = other.Coordinates.X + other.Width;

            double otherY1 = other.Coordinates.Y;
            double otherY2 = other.Coordinates.Y + other.Height;

            return IsInside(otherX1, otherY1)
                || IsInside(otherX1, otherY2)
                || IsInside(otherX2, otherY1)
                || IsInside(otherX2, otherY2);
        }

        private bool IsInside(double otherX, double otherY)
        {
            var thisX = this.Coordinates.X;
            var thisY = this.Coordinates.Y;

            return (thisX <= otherX && otherX <= (thisX + this.Width))
                && (thisY <= otherY && otherY <= (thisY + this.Height));
        }
    }
}