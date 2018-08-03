package exercises;

import java.util.Scanner;

public class x17ChangeToUppercase
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);

        String text = console.nextLine();

        text = text.replaceAll("<upcase>(.+?)</upcase>","<mycase>$1<mycase>");
        String[] textComponents = text.split("<mycase>");

        for (int i = 0; i < textComponents.length; i++)
        {
            if (i % 2 != 0)
            {
                textComponents[i]  = textComponents[i].toUpperCase();
            }
        }

        System.out.println(String.join("", textComponents));
    }
}
/*
as<upcase>test</upcase> Welcome to the <upcase>Software University</upcase>. Learn <upcase>computer programming</upcase> and start a <upcase>job</upcase> in a software company. <upcase>test</upcase>dd
 */
