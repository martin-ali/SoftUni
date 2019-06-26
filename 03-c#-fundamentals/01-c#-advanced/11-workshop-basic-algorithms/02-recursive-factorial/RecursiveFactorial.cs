using System;

namespace _02_recursive_factorial
{
    class RecursiveFactorial
    {
        static void Main()
        {
            var factorialIndex = int.Parse(Console.ReadLine());

            var factorial = GetFactorial(factorialIndex);

            Console.WriteLine(factorial);
        }

        private static long GetFactorial(int factorialIndex)
        {
            if (factorialIndex == 1)
            {
                return 1;
            }

            var factorial = factorialIndex * GetFactorial(factorialIndex - 1);

            return factorial;
        }
    }
}
