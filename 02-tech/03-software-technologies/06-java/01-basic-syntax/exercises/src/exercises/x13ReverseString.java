package exercises;

import java.util.Scanner;

public class x13ReverseString
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);
        String input = console.nextLine();

//        for (int i = text.length() - 1; i >=0; i--)
//        {
//            System.out.print(text.charAt(i));
//        }

        String reversedInput = new StringBuilder(input).reverse().toString();
        System.out.println(reversedInput);
    }
}
