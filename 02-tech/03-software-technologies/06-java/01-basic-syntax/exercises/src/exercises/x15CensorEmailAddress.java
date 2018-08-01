package exercises;

import java.util.Scanner;

public class x15CensorEmailAddress
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);

        String email = console.nextLine();
        String text = console.nextLine();

        int indexOfAt = email.indexOf("@");
        String username = email.substring(0, indexOfAt);
        String domain = email.substring(indexOfAt);

        String censor = username.replaceAll(".","*") + domain;

        String censoredText = text.replaceAll(email, censor);
        System.out.println(censoredText);
    }
}
/*
pesho.peshev@email.bg
My name is Pesho Peshev. I am from Sofia, my email is: pesho.peshev@email.bg (not pesho.peshev@email.com). Test: pesho.meshev@email.bg, pesho.peshev@email.bg
 */