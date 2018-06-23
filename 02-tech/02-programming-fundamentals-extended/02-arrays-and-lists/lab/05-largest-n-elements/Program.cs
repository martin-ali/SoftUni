using System;
using System.Linq;

namespace _05_largest_n_elements
{
    class Program
    {
        static void Main()
        {
            var arr = Console
              .ReadLine()
              .Split(new char[] { ' ' }, StringSplitOptions.None)
              .Select(x => decimal.Parse(x))
              .ToList();
            var numberOfElementsToPrint = int.Parse(Console.ReadLine());

            arr.Sort((a, b) => -a.CompareTo(b));
            Console.WriteLine(String.Join(" ", arr.Take(numberOfElementsToPrint)));
        }
    }
}
