using System;

namespace _07_greatest_common_divisor
{
    class Program
    {
        static void Main()
        {
            int numA = int.Parse(Console.ReadLine());
            int numB = int.Parse(Console.ReadLine());

            Console.WriteLine(findGreatestCommonDivisor(numA, numB));
        }

        static int findGreatestCommonDivisor(int a, int b)
        {
            // Find more elegant way
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }

            if (a > b)
            {
                int greatestCommonDivisor = findGreatestCommonDivisor(a % b, b);
                return greatestCommonDivisor;                
            }
            else
            {
                int greatestCommonDivisor = findGreatestCommonDivisor(a, b % a);
                return greatestCommonDivisor; 
            }
        }
    }
}
