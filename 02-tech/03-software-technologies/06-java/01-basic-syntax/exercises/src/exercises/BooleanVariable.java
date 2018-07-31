package exercises;

import java.util.Scanner;

public class BooleanVariable
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);
        String booleanVariable = console.nextBoolean() ? "Yes" : "No";

        System.out.println(booleanVariable);
    }
}
