using System;

namespace _06_strings_and_objects
{
    class StringsAndObjects
    {
        static void Main()
        {
            string hello = "Hello";
            string World = "World";
            object helloWorldObj = $"{hello} {World}";
            string helloWorld = helloWorldObj.ToString();
            Console.WriteLine(helloWorld);
        }
    }
}
