using System;
using System.Collections.Generic;

namespace _01_unique_usernames
{
    class UniqueUsernames
    {
        static void Main()
        {
            var namesCount = int.Parse(Console.ReadLine());
            var names = new HashSet<string>();

            for (int i = 0; i < namesCount; i++)
            {
                names.Add(Console.ReadLine());
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
