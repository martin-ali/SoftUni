package exercises;

import java.util.HashMap;
import java.util.Scanner;

public class x18Phonebook
{
    public static void main(String[] args)
    {
        HashMap<String,String> phonebook = new HashMap<>();
        Scanner console = new Scanner(System.in);

        String input = console.nextLine();
        while (!input.equals("END"))
        {

            String[] data = input.split(" ");
            String command = data[0];
            String name = data[1];

            if (command.equals("A"))
            {
                String phone = data[2];
                phonebook.put(name, phone);
            }
            else // command.equals("S")
            {
                if (phonebook.containsKey(name))
                {
                    System.out.println(String.format("%s -> %s", name, phonebook.get(name)));
                }
                else
                {
                    System.out.println(String.format("Contact %s does not exist.", name));
                }
            }

            input = console.nextLine();
        }
    }
}
/*
A Nakov 0888080808
S Mariika
S Nakov
END
 */