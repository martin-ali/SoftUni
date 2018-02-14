using System;

namespace Triangle_Of_Dollars
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
