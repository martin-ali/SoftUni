using System;

namespace _08_sum_of_odd_numbers
{
    class SumOfOddNumbers
    {
        static void Main()
        {
            int oddNumbers = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= oddNumbers * 2; i += 2)
            {
                Console.WriteLine(i);
                sum += i;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
