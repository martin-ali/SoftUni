using System;

namespace Greeting
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine("Enter your name: ");
            var name = Console.ReadLine();

            Console.WriteLine($"Hello, {name}!");
        }
    }
}
