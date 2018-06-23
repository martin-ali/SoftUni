using System;

namespace _10_check_if_prime_number
{
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(isPrime(number) ? "Prime" : "Not Prime");
        }

        private static bool isPrime(int numberToCheck)
        {
            if (numberToCheck < 2)
            {
                return false;
            }
            
            for (int current = 2; current < numberToCheck; current++)
            {
                if (numberToCheck % current == 0) return false;
            }

            return true;
        }
    }
}
