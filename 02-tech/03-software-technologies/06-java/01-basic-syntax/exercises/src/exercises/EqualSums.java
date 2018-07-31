package exercises;

import java.util.Arrays;
import java.util.Scanner;

public class EqualSums
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);
        int[] numbers = Arrays.stream(console.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        for (int i = 0; i < numbers.length; i++)
        {
            int leftSum = sumRange(0, i, numbers);
            int rightSum = sumRange(i + 1, numbers.length, numbers);

            if (leftSum == rightSum)
            {
                System.out.println(i);
                return;
            }
        }

        System.out.println("no");
    }

    public static int sumRange(int start, int end, int[] numbers)
    {
        int sum = 0;
        for (int i = start; i < end; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }
}
