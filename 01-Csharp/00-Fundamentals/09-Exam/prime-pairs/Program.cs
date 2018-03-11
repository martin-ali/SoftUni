using System;

namespace prime_pairs
{
    class Program
    {
        static void Main()
        {
            int firstPairStart = int.Parse(Console.ReadLine());
            int secondPairStart = int.Parse(Console.ReadLine());
            int firstPairDifference = int.Parse(Console.ReadLine());
            int secondPairDifference = int.Parse(Console.ReadLine());

            for (int i = firstPairStart; i <= firstPairStart + firstPairDifference; i++)
            {
                for (int j = secondPairStart; j <= secondPairStart + secondPairDifference; j++)
                {
                    if (IsPrime(i) && IsPrime(j))
                    {
                        Console.WriteLine($"{i}{j}");
                    }
                }
            }
        }

        static bool IsPrime(int number)
        {
            if (number == 2 || number % 2 == 0 || number == 1 || number == 0)
            {
                return false;
            }

            for (int i = 3; i < number; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
