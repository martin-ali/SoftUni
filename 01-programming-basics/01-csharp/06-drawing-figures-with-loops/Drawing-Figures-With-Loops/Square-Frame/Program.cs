using System;
using System.Text;

namespace Square_Frame
{
    class Program
    {
        static void Main()
        {

            var size = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();
            builder.Append(new string('-', size - 2));

            var middle = builder.ToString();
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
