package exercises;

import java.util.Scanner;

public class IndexOfLetters
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);
        String text = console.next();

        for (int i = 0; i < text.length(); i++)
        {
            char symbol = text.charAt(i);
            int charCode = symbol - 97;
            System.out.println(symbol + " -> " + charCode);
        }
    }
}
