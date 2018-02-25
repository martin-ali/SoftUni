using System;
using System.Linq;

namespace special_numbers
{
    class Program
    {
        static void Main()
        {
            int specialNumber = int.Parse(Console.ReadLine());

            for (int first = 1; first <= 9; first++)
            {
                for (int second = 1; second <= 9; second++)
                {
                    for (int third = 1; third <= 9; third++)
                    {
                        for (int fourth = 1; fourth <= 9; fourth++)
                        {
                            var specialNumberIsDivisibleByAllDigits = specialNumber % first == 0
                                    && specialNumber % second == 0
                                    && specialNumber % third == 0
                                    && specialNumber % fourth == 0;
                                    
                            if (specialNumberIsDivisibleByAllDigits)
                            {
                                Console.Write($"{first}{second}{third}{fourth} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
