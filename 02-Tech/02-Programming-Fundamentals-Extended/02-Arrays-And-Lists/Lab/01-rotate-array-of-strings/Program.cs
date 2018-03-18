using System;

namespace _01_rotate_array_of_strings
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.None);
            // var arr = new string[] { "a", "b", "c", "d", "e" };
            var rotatedArr = new string[arr.Length];

            rotatedArr[0] = arr[arr.Length - 1];
            var index = 1;
            while (index < arr.Length)
            {
                rotatedArr[index] = arr[index - 1];
                index++;
            }

            Console.WriteLine(String.Join(" ", rotatedArr));
        }
    }
}
