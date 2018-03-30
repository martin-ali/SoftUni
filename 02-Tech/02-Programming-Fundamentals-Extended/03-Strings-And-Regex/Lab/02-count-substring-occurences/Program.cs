using System;

namespace _02_count_substring_occurences
{
    class Program
    {
        static void Main()
        {
            var text = Console.ReadLine().ToLower();
            var substring = Console.ReadLine().ToLower();

            var occurrences = text.Split(new string[] { substring }, StringSplitOptions.None).Length - 1;
            Console.WriteLine(occurrences);
        }
    }
}
