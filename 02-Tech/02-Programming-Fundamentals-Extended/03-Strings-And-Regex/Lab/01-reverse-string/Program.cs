using System;

namespace _01_reverse_string
{
    class Program
    {
        static void Main()
        {
            var str = Console.ReadLine().ToCharArray();

            var index = str.Length;
            while (--index >= 0)
            {
                Console.Write(str[index]);
            }
        }
    }
}