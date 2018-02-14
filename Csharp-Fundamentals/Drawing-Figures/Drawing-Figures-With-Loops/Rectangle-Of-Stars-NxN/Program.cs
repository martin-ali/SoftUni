using System;

namespace Rectangle_Of_Stars_NxN
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
