package exercises;

import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

public class x03ReverseCharacters
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);
        String[] characters = new String[3];

        for (int i = 0; i < 3; i++)
        {
            characters[i] = console.next();
        }

        Collections.reverse(Arrays.asList(characters));
        System.out.println(String.join("", characters));
    }
}
