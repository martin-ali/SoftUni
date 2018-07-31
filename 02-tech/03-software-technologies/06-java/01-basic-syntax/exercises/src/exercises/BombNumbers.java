package exercises;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class BombNumbers
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);
        ArrayList<String> field = new ArrayList<>(Arrays.asList(console.nextLine().split(" ")));
        int[] stats = Arrays.stream(console.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        String bomb = stats[0]+"";
        int power = stats[1];

        for (int i = 0; i < field.size(); i++)
        {
            if(field.get(i).equals(bomb))
            {
                int start = Math.max(i-power, 0);
                int end = Math.min(i+power+1, field.size());

                field.subList(start,end).clear();
                i=0;
            }
        }

        long sum = 0;
        for (String number: field)
        {
            sum+=(Integer.parseInt(number));
        }

        System.out.println(sum);
    }
}

/*

1 2 2 4 2 2 2 9 4
4 2

 */