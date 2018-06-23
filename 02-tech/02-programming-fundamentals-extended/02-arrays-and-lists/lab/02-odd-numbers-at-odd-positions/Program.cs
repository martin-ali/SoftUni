using System;

namespace _02_odd_numbers_at_odd_positions
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None);

            var index = 1;
            while (index < arr.Length)
            {
                if (int.Parse(arr[index]) % 2 != 0) Console.WriteLine($"Index {index} -> {arr[index]}");
                index += 2;
            }
        }
    }
}
