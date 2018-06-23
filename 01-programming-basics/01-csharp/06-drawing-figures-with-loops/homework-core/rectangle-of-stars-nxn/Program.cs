using System;

namespace rectangle_of_stars_nxn
{
    class Program
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            for (int row = 0; row < size; row++)
            {
                Console.WriteLine(new string('*', size));
            }
        }
    }
}
