using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_primes_in_given_range
{
    class PrimesInGivenRange
    {
        static void Main()
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var primes = FindPrimesInRange(start, end);
            Console.WriteLine(String.Join(", ", primes));
        }

        // Sieve of Eratosthenes
        private static List<int> FindPrimesInRange(int start, int end)
        {
            var sieve = new int[end + 1];

            // Remove all even numbers from sieve
            sieve[2] = 2;
            for (int index = 4; index < sieve.Length; index += 2)
            {
                sieve[index] = -1;
            }

            // Get odd number N then remove every Nth number, unless previously removed
            for (int primeCandidate = 3; primeCandidate < sieve.Length; primeCandidate += 2)
            {
                // If number has been removed before, skip it
                if (sieve[primeCandidate] < 0)
                {
                    continue;
                }

                sieve[primeCandidate] = primeCandidate;
                for (int nextOccurrence = primeCandidate + primeCandidate; nextOccurrence < sieve.Length; nextOccurrence += primeCandidate)
                {
                    sieve[nextOccurrence] = -1;
                }
            }

            return sieve
                    .Skip(start)
                    .Where(prime => prime > 0)
                    .Take(end - start)
                    .ToList();
        }
    }
}
