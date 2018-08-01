package exercises;

import java.util.Arrays;
import java.util.Scanner;

public class x07MaxSequenceOfEqualElements
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);
        int[] numbers = Arrays.stream(console.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        int longestRepeatingElement = numbers[0];
        int longestSequence = 0;

        int currentElement = numbers[0];
        int currentSequence = 1;

        for (int i = 1; i < numbers.length; i++)
        {
            int previous = numbers[i - 1];
            int current = numbers[i];

            if (previous == current)
            {
                currentSequence++;
            }
            else
            {
                currentSequence = 1;
                currentElement = current;
            }

            if (currentSequence > longestSequence)
            {
                longestSequence = currentSequence;
                longestRepeatingElement = currentElement;
            }
        }

        for (int i = 0; i < longestSequence; i++)
        {
            System.out.print(longestRepeatingElement + " ");
        }
    }
}
