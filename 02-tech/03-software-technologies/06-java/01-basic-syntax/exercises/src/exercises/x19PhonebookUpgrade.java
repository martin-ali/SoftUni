package exercises;

import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class x19PhonebookUpgrade
{
    public static void main(String[] args)
    {
        TreeMap<String,String> phonebook = new TreeMap<>();
        Scanner console = new Scanner(System.in);

        String input = console.nextLine();
        while (!input.equals("END"))
        {
            String[] data = input.split(" ");
            String command = data[0];

            if (command.equals("A"))
            {
                String name = data[1];
                String phone = data[2];
                phonebook.put(name, phone);
            }
            else if (command.equals("S"))
            {
                String name = data[1];
                if (phonebook.containsKey(name))
                {
                    System.out.println(String.format("%s -> %s", name, phonebook.get(name)));
                }
                else
                {
                    System.out.println(String.format("Contact %s does not exist.", name));
                }
            }
            else
            {
                for (Map.Entry<String,String> entry: phonebook.entrySet())
                {
                    System.out.println(String.format("%s -> %s", entry.getKey(), entry.getValue()));
                }
            }

            input = console.nextLine();
        }
    }
}
/*
A Nakov +359888001122
A RoYaL(Ivan) 666
A Gero 5559393
A Simo 02/987665544
ListAll
END
 */