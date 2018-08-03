package exercises;

public class Circle
{
    private Point center;
    private int radius;

    public Circle(Point center, int radius)
    {
        this.center = center;
        this.radius = radius;
    }

    public Boolean intersects(Circle otherCircle)
    {
        int bothRadii = this.getRadius() + otherCircle.getRadius();
        double horizontalDistance = Math.pow(this.getCenter().getX() - otherCircle.getCenter().getX(), 2);
        double verticalDistance = Math.pow(this.getCenter().getY() - otherCircle.getCenter().getY(), 2);
        double centersDistance = Math.sqrt(horizontalDistance + verticalDistance);

        return (centersDistance <= bothRadii);
    }

    public Point getCenter()
    {
        return center;
    }

    public void setCenter(Point center)
    {
        this.center = center;
    }

    public int getRadius()
    {
        return radius;
    }

    public void setRadius(int radius)
    {
        this.radius = radius;
    }
}
