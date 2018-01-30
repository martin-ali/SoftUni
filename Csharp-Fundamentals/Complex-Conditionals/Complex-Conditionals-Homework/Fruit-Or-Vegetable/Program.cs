using System;
using System.Collections.Generic;

namespace Fruit_Or_Vegetable
{
    class Program
    {
        static void Main()
        {
            HashSet<string> fruits = new HashSet<string>
            {
                {"banana"},
                {"apple"},
                {"kiwi"},
                {"cherry"},
                {"lemon"},
                {"grapes"}
            };

            HashSet<string> vegetables = new HashSet<string>
            {
                {"tomato"},
                {"cucumber"},
                {"pepper"},
                {"carrot"}
            };

            var produce = Console.ReadLine();
            var produceType = "unknown";
            
            if (fruits.Contains(produce))
            {
                produceType = "fruit";
            }
            else if (vegetables.Contains(produce))
            {
                produceType = "vegetable";
            }

            Console.WriteLine(produceType);
        }
    }
}
