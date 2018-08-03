package exercises;

import java.util.Scanner;

public class x22IntersectionOfCircles
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);

        int firstCircleX = console.nextInt();
        int firstCircleY = console.nextInt();
        int firstCircleRadius = console.nextInt();

        int secondCircleX = console.nextInt();
        int secondCircleY = console.nextInt();
        int secondCircleRadius = console.nextInt();

        Circle firstCircle = new Circle(new Point(firstCircleX, firstCircleY), firstCircleRadius);
        Circle secondCircle = new Circle(new Point(secondCircleX, secondCircleY), secondCircleRadius);
        String doTheyIntersect = firstCircle.intersects(secondCircle) ? "Yes" : "No";

        System.out.println(doTheyIntersect);
    }
}