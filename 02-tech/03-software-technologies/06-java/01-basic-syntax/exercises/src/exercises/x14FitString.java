package exercises;

import java.util.Scanner;

public class x14FitString
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);
        String input = console.nextLine();

        for (int i = 0; i < 20; i++)
        {
            char character = (i < input.length())
                                ? input.charAt(i)
                                : '*';

            System.out.print(character);
        }
    }
}
