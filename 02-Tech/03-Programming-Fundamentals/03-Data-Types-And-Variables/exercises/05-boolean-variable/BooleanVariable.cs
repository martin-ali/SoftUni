using System;

namespace _05_boolean_variable
{
    class BooleanVariable
    {
        static void Main()
        {
            var boolean = Console.ReadLine();
            Console.WriteLine(boolean == "True" ? "Yes" : "No");
        }
    }
}
