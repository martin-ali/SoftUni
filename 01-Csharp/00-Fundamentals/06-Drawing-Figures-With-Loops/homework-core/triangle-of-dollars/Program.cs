using System;

namespace triangle_of_dollars
{
    class Program
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            for (int current = 1; current <= size; current++)
            {
                Console.WriteLine(String.Join(" ", new string('$', current).ToCharArray()));
            }
        }
    }
}
