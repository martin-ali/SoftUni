using System;
using System.Linq;

namespace _01_action_print
{
    class ActionPrint
    {
        static void Main()
        {
            Action<string> print = x => Console.WriteLine(x);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(print);
        }
    }
}
