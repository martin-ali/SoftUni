using System;

namespace rectangle_of_stars_10x10
{
    class Program
    {
        static void Main()
        {
            for (int row = 0; row < 10; row++)
            {
                Console.WriteLine(new string('*', 10));
            }
        }
    }
}
