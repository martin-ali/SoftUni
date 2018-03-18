using System;

namespace _03_array_contains_element
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None);
            var elementToFind = Console.ReadLine();

            var isElementFound = "no";
            foreach (var current in arr)
            {
                if (current == elementToFind) isElementFound = "yes";
            }

            Console.WriteLine(isElementFound);
        }
    }
}
