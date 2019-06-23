using System;

namespace _01_generic_box_of_string
{
    class GenericBoxOfString
    {
        static void Main()
        {
            var stringCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < stringCount; i++)
            {
                var item = Console.ReadLine();

                var box = new Box<string>(item);

                Console.WriteLine(box);
            }
        }
    }
}
