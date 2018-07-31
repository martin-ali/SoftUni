package exercises;

import java.util.Scanner;

public class CompareCharArrays
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);
        String first = console.nextLine().replace(" ", "");
        String second = console.nextLine().replace(" ", "");

        int limit = first.length() < second.length() ? first.length() : second.length();
        boolean firstStringComesFirst = first.length() < second.length();

        for (int i = 0; i < limit; i++)
        {
            if (first.charAt(i) < second.charAt(i))
            {
                firstStringComesFirst = true;
                break;
            }
            else if (first.charAt(i) > second.charAt(i))
            {
                firstStringComesFirst = false;
                break;
            }
        }

        if (firstStringComesFirst)
        {
            System.out.println(first);
            System.out.println(second);
        }
        else
        {
            System.out.println(second);
            System.out.println(first);
        }
    }
}