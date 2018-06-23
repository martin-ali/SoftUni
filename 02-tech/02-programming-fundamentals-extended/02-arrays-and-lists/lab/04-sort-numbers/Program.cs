using System;
using System.Linq;

namespace _04_sort_numbers
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
                        
            arr.Sort();

            Console.WriteLine(String.Join(" <= ", arr));
        }
    }
}
