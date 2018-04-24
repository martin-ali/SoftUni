using System;

namespace _07_greeting
{
    class Greeting
    {
        static void Main()
        {
            var firstName = Console.ReadLine();
            var lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Hello, {firstName} {lastName}. You are {age} years old.");
        }
    }
}
