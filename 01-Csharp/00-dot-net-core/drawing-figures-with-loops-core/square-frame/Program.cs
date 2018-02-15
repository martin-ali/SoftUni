using System;

namespace square_frame
{
    class Program
    {
        static void Main()
        {
            // Re-write without StringBuilder for .Net Core
            var size = int.Parse(Console.ReadLine());
            var middle = new string('-', size - 2);
            var topAndBottomFrame = String.Join(" ", ($"+{middle}+").ToCharArray());
            var midsection = String.Join(" ", ($"|{middle}|").ToCharArray());

            Console.WriteLine(topAndBottomFrame);

            for (int current = 2; current < size; current++)
            {
                Console.WriteLine(midsection);
            }

            Console.WriteLine(topAndBottomFrame);
        }
    }
}
