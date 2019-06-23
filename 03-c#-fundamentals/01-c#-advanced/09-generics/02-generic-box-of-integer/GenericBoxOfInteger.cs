using System;

namespace _02_generic_box_of_integer
{
    class GenericBoxOfInteger
    {
        static void Main()
        {
            var stringCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < stringCount; i++)
            {
                var item = int.Parse(Console.ReadLine());

                var box = new Box<int>(item);

                Console.WriteLine(box);
            }
        }
    }
}
