using System;
using System.Linq;

namespace _01_action_point
{
    class ActionPoint
    {
        static void Main()
        {
            Action<string> print = item => Console.WriteLine(item);

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(print);
        }
    }
}
