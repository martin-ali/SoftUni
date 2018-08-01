package exercises;

import java.util.Arrays;
import java.util.Scanner;

public class x04VowelOrDigit
{
    public static void main(String[] args)
    {
        String[] digits = "0123456789".split("");
        String[] vowels = "aeiou".split("");

        Scanner console = new Scanner(System.in);
        String symbol = console.next();

        if (Arrays.asList(digits).contains(symbol))
        {
            System.out.println("digit");
        }
        else if (Arrays.asList(vowels).contains(symbol.toLowerCase()))
        {
            System.out.println("vowel");
        }
        else
        {
            System.out.println("other");
        }
    }
}