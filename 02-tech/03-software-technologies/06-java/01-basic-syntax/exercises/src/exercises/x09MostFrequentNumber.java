package exercises;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class x09MostFrequentNumber
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);
        int[] numbers = Arrays.stream(console.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        ArrayList<Integer> currentSequence = new ArrayList<Integer>();
        currentSequence.add(numbers[0]);
        ArrayList<Integer> longestSequence = new ArrayList<Integer>();

        for (int i = 1; i < numbers.length; i++)
        {
        }

        for (Integer number : longestSequence)
        {
            System.out.print(number + " ");
        }
    }
}
