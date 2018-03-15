using System;

namespace special_combinations
{
    class Program
    {
        static void Main()
        {
            int hundredsUpperCeiling = int.Parse(Console.ReadLine());
            int tensUpperCeiling = int.Parse(Console.ReadLine());
            int singlesUpperCeiling = int.Parse(Console.ReadLine());
            int[] firstPrimes = new int[] { 2, 3, 5, 7 };

            for (int hundreds = 2; hundreds <= hundredsUpperCeiling; hundreds += 2)
            {
                for (int j = 0; j < 4 && firstPrimes[j] <= tensUpperCeiling; j++)
                {
                    var tens = firstPrimes[j];
                    for (int singles = 2; singles <= singlesUpperCeiling; singles += 2)
                    {
                        Console.WriteLine($"{hundreds} {tens} {singles}");
                    }
                }
            }
        }
    }
}
