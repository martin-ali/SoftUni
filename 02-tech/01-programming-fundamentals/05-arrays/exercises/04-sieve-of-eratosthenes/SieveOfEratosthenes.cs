using System;
using System.Linq;

namespace _04_sieve_of_eratosthenes
{
    class SieveOfEratosthenes
    {
        static void Main()
        {
            var rangeEnd = int.Parse(Console.ReadLine());

            var primes = new bool[rangeEnd + 1].Select(x => true).ToArray();
            primes[0] = primes[1] = false;

            for (int candidate = 0; candidate <= rangeEnd; candidate++)
            {
                if (primes[candidate])
                {
                    Console.Write(candidate + " ");
                    for (int current = candidate + candidate; current <= rangeEnd; current += candidate)
                    {
                        primes[current] = false;
                    }
                }
            }
        }
    }
}
