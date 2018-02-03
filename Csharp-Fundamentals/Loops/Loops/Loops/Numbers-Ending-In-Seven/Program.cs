using System;

namespace Numbers_Ending_In_Seven
{
    class Program
    {
        static void Main()
        {
            for (int current = 1; current <= 1000; current++)
            {
                bool numberEndsInSeven = current % 10 == 7;
                if (numberEndsInSeven)
                {
                    Console.WriteLine(current);
                }
            }
        }
    }
}
