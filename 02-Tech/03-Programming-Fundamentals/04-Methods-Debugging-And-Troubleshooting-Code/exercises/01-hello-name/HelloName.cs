using System;

namespace _01_hello_name
{
    class HelloName
    {
        static void Main()
        {
            var name = Console.ReadLine();
            PrintHello(name);
        }

        private static void PrintHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
