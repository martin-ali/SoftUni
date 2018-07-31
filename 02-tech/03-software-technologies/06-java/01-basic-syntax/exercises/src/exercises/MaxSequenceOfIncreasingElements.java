package exercises;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Scanner;

public class MaxSequenceOfIncreasingElements
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);
        int[] numbers = Arrays.stream(console.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        HashMap<Integer, Integer> occurrencesByNumber = new HashMap<>();

        int mostFrequentCount = 0;
        int mostFrequentNumber = numbers[0];
        for (int i = 0; i < numbers.length; i++)
        {
            int current = numbers[i];
            if (occurrencesByNumber.containsKey(current) == false)
            {
                occurrencesByNumber.put(current, 0);
            }

            int previousOccurrences = occurrencesByNumber.get(current);
            occurrencesByNumber.put(current, previousOccurrences + 1);

            if (occurrencesByNumber.get(current) > mostFrequentCount)
            {
                mostFrequentCount = occurrencesByNumber.get(current);
                mostFrequentNumber = current;
            }
        }

        System.out.println(mostFrequentNumber);
    }
}
