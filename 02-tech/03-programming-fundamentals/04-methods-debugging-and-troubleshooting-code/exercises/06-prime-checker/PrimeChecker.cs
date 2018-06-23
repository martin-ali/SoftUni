using System;

namespace _06_prime_checker
{
    class PrimeChecker
    {
        static void Main()
        {
            var number = long.Parse(Console.ReadLine());
            Console.WriteLine(isPrime(number));
        }

        private static bool isPrime(long number)
        {
            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0 || number <= 1)
            {
                return false;
            }

            var sqrtNumber = Math.Sqrt(number);
            for (int current = 3; current <= sqrtNumber; current += 2)
            {
                if (number % current == 0) return false;
            }

            return true;
        }
    }
}
