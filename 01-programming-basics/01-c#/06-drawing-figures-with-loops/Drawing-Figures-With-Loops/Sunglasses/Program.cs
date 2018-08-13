using System;

namespace Sunglasses
{
    class Program
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var tow = new string('*', size * 2) + new string(' ', size) + new string('*', size * 2);

            Console.WriteLine(tow);

            for (int current = 1; current <= size - 2; current++)
            {
                var noseChar = ' ';

                if (current == ((size - 1) / 2))
                {
                    noseChar = '|';
                }

                var glasses = new string('/', (size * 2) - 2);
                var middle = new string(noseChar, size);

                Console.WriteLine($"*{glasses}*{middle}*{glasses}*");
            }

            Console.WriteLine(tow);
        }
    }
}
