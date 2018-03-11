using System;

namespace SquareOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            Console.WriteLine(new string('*', size));

            for (int rows = 0; rows < size - 2; rows++)
            {
                Console.WriteLine('*' + new string(' ', size - 2) + '*');
            }

            Console.WriteLine(new string('*', size));
        }
    }
}
