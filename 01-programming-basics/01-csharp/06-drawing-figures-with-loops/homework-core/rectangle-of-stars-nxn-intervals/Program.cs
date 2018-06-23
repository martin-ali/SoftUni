using System;

namespace rectangle_of_stars_nxn_intervals
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
