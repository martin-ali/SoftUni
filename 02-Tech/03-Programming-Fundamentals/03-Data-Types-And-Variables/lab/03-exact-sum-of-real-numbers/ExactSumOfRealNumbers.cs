using System;

namespace _03_exact_sum_of_real_numbers
{
    class ExactSumOfRealNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var sum = 0m;
            while (n-- > 0)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
