using System;

namespace _12_test_numbers
{
    class TestNumbers
    {
        static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());
            byte m = byte.Parse(Console.ReadLine());
            int maxSum = int.Parse(Console.ReadLine());
            var sum = 0;
            var numberOfCombinations = 0;

            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (sum >= maxSum)
                    {
                        break;
                    }

                    numberOfCombinations++;
                    var result = (i * j) * 3;
                    sum += result;
                }
            }

            Console.WriteLine($"{numberOfCombinations} combinations");
            if (sum >= maxSum)
            {
                Console.WriteLine($"Sum: {sum} >= {maxSum}");
            }
            else
            {
                Console.WriteLine($"Sum: {sum}");
            }
        }
    }
}
