using System;

namespace _15_fast_prime_checker_refactor
{
    class FastPrimeCheckerRefactor
    {
        static void Main()
        {
            int numberToCheckUpTo = int.Parse(Console.ReadLine());
            for (int testedNumber = 2; testedNumber <= numberToCheckUpTo; testedNumber++)
            {
                bool isPrime = true;
                var testedNumberRoot = Math.Sqrt(testedNumber);
                for (int currentNumber = 2; currentNumber <= testedNumberRoot; currentNumber++)
                {
                    if (testedNumber % currentNumber == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine($"{testedNumber} -> {isPrime}");
            }
        }
    }
}
