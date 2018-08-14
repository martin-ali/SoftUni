using System;
using System.Collections.Generic;

namespace _08_recursive_fibonacci
{
    class RecursiveFibonacci
    {
        public static Dictionary<int, long> memoizedFibonacci = new Dictionary<int, long>()
        {
            [0] = 0,
            [1] = 1,
            [2] = 1,
        };

        static void Main()
        {
            var fibonacci = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(fibonacci));
        }

        public static long GetFibonacci(int n)
        {
            if (memoizedFibonacci.ContainsKey(n))
            {
                return memoizedFibonacci[n];
            }

            var fibonacci = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            memoizedFibonacci[n] = fibonacci;

            return fibonacci;
        }
    }
}
