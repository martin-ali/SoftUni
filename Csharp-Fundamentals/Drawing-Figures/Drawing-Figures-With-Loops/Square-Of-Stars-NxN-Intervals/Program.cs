using System;

namespace Square_Of_Stars_NxN_Intervals
{
    class Program
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            for (int row = 0; row < size; row++)
            {
                Console.WriteLine(String.Join(" ", new string('*', size).ToCharArray()));
            }
        }
    }
}
